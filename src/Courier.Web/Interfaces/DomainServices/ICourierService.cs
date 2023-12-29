using Courier.Web.Models;

namespace Courier.Web.Interfaces.DomainServices;

using Courier.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICourierService
{
    Task<Delivery> ClaimOrder(long orderId, long courierId, string deliveryAddress);
    Task<Delivery> MarkOrderDelivered(long orderId);
    Task<Delivery> GetDeliveryById(long id);
    Task<Delivery> CreateDelivery(Delivery delivery);
    Task<Delivery> UpdateDelivery(Delivery delivery);
    Task DeleteDelivery(Delivery delivery);
    Task<IEnumerable<Delivery>> GetAllDeliveries();
    Task<IEnumerable<Delivery>> GetDeliveriesByCourierId(long courierId);
    Task<IEnumerable<Delivery>> GetDeliveriesByOrderId(long orderId);
    Task<IEnumerable<Delivery>> GetDeliveriesByStatus(DeliveryStatus deliveryStatus);
    Task<IEnumerable<Delivery>> GetDeliveriesByCourierIdAndStatus(long courierId, DeliveryStatus deliveryStatus);
}

