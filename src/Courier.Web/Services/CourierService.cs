using Courier.Web.Entities;
using Courier.Web.Interfaces.DomainServices;
using Courier.Web.Interfaces.Repositories;
using Courier.Web.Models;
using Courier.Web.Models.Dto;
using Courier.Web.Producer;
using Courier.Web.Specifications;

namespace Courier.Web.Services;

public class CourierService : ICourierService
{
    private readonly IReadRepository<Delivery> _deliveryReadRepository;
    private readonly IRepository<Delivery> _deliveryRepository;
    private readonly KafkaProducer _kafkaProducer;
    private readonly IGeocodingService _geocodingService;
    
    public CourierService(IReadRepository<Delivery> deliveryReadRepository, IRepository<Delivery> deliveryRepository, KafkaProducer kafkaProducer, IGeocodingService geocodingService)
    {
        _deliveryReadRepository = deliveryReadRepository;
        _deliveryRepository = deliveryRepository;
        _kafkaProducer = kafkaProducer;
        _geocodingService = geocodingService;
    }
    
    public async Task<Delivery> MarkOrderDelivered(long orderId)
    {
        var delivery = await _deliveryReadRepository.GetByIdAsync(new OrderDeliveriesSpecification(orderId));
        if (delivery == null) return null;
        
        ClaimOrderDto claimOrderDto = new()
        {
            OrderId = orderId
        };
        
        delivery.DeliveryStatus = DeliveryStatus.Delivered;
        delivery.TimeDelivered = DateTime.UtcNow;
        
        await _deliveryRepository.UpdateAsync(delivery);
        
        await _kafkaProducer.ProduceAsync("mtogo-completed-deliveries", claimOrderDto);
        
        return delivery;
    }
    
    public async Task<Delivery> ClaimOrder(long orderId, long courierId, string deliveryAddress)
    {
        var coordinates = await _geocodingService.GetCoordinatesFromAddress(deliveryAddress);
        var delivery = new Delivery
        {
            OrderId = orderId,
            CourierId = courierId,
            DeliveryAddress = deliveryAddress,
            DeliveryStatus = DeliveryStatus.Claimed,
            TimeClaimed = DateTime.UtcNow,
            Latitude = coordinates?.Latitude,
            Longitude = coordinates?.Longitude
        };
        await _deliveryRepository.AddAsync(delivery);
        await _kafkaProducer.ProduceAsync("mtogo-claimed-deliveries", new ClaimOrderDto { OrderId = orderId });
        return delivery;
    }

    
    // TODO: Review below implementation of methods. 
    
    public async Task<Delivery> GetDeliveryById(long id)
    {
        var delivery = await _deliveryReadRepository.GetByIdAsync(id);
        return delivery;
    }
    
    public async Task<Delivery> CreateDelivery(Delivery delivery)
    {
        await _deliveryRepository.AddAsync(delivery);
        return delivery;
    }
    
    public async Task<Delivery> UpdateDelivery(Delivery delivery)
    {
        await _deliveryRepository.UpdateAsync(delivery);
        return delivery;
    }
    
    public async Task DeleteDelivery(Delivery delivery)
    {
        await _deliveryRepository.DeleteAsync(delivery);
    }
    
    public async Task<IEnumerable<Delivery>> GetAllDeliveries()
    {
        var allDeliveriesSpec = new AllDeliveriesSpecification();
        var deliveries = await _deliveryReadRepository.ListAsync(allDeliveriesSpec);
        return deliveries;
    }
    
    public async Task<IEnumerable<Delivery>> GetDeliveriesByCourierId(long courierId)
    {
        var deliveries = await _deliveryReadRepository.ListAsync(new CourierDeliveriesSpecification(courierId));
        return deliveries;
    }
    
    public async Task<IEnumerable<Delivery>> GetDeliveriesByOrderId(long orderId)
    {
        var deliveries = await _deliveryReadRepository.ListAsync(new OrderDeliveriesSpecification(orderId));
        return deliveries;
    }
    
    public async Task<IEnumerable<Delivery>> GetDeliveriesByStatus(DeliveryStatus deliveryStatus)
    {
        var deliveries = await _deliveryReadRepository.ListAsync(new DeliveryStatusSpecification(deliveryStatus));
        return deliveries;
    }
    
    public async Task<IEnumerable<Delivery>> GetDeliveriesByCourierIdAndStatus(long courierId, DeliveryStatus deliveryStatus)
    {
        var deliveries = await _deliveryReadRepository.ListAsync(new CourierDeliveriesSpecification(courierId, deliveryStatus));
        return deliveries;
    }
}
