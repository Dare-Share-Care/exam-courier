using Microsoft.AspNetCore.Mvc;
using Courier.Web.Entities;
using Courier.Web.Interfaces.DomainServices;
using Courier.Web.Models;
using Courier.Web.Models.Dto;

namespace Courier.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;
    private readonly IGeocodingService _geocodingService;

    public CourierController(ICourierService courierService, IGeocodingService geocodingService)
    {
        _courierService = courierService;
        _geocodingService = geocodingService;
    }
    
    // POST: api/courier/mark-order-delivered
    [HttpPost("mark-order-delivered")]
    public async Task<ActionResult<Delivery>> MarkOrderDelivered(long orderId)
    {
        var delivery = await _courierService.MarkOrderDelivered(orderId);
        if (delivery == null) return NotFound();
        return Ok(delivery);
    }
    
    [HttpPost("claim-order")]
    public async Task<ActionResult<Delivery>> ClaimOrder([FromBody] ClaimOrderDto claimdto)
    {
        var coordinates = await _geocodingService.GetCoordinatesFromAddress(claimdto.DeliveryAddress);

        var claimedDelivery = await _courierService.ClaimOrder(claimdto.OrderId, claimdto.CourierId, claimdto.DeliveryAddress);
        return CreatedAtAction(nameof(GetDeliveryById), new { id = claimedDelivery.Id }, claimedDelivery);
    }


    [HttpGet("delivery/{id}")]
    public async Task<ActionResult<Delivery>> GetDeliveryById(long id)
    {
        var delivery = await _courierService.GetDeliveryById(id);
        if (delivery == null) return NotFound();
        return Ok(delivery);
    }

    [HttpPost("delivery")]
    public async Task<ActionResult<Delivery>> CreateDelivery([FromBody] Delivery delivery)
    {
        var createdDelivery = await _courierService.CreateDelivery(delivery);
        return CreatedAtAction(nameof(GetDeliveryById), new { id = createdDelivery.Id }, createdDelivery);
    }

    [HttpPut("delivery")]
    public async Task<IActionResult> UpdateDelivery([FromBody] Delivery delivery)
    {
        await _courierService.UpdateDelivery(delivery);
        return NoContent();
    }

    [HttpDelete("delivery")]
    public async Task<IActionResult> DeleteDelivery([FromBody] Delivery delivery)
    {
        await _courierService.DeleteDelivery(delivery);
        return NoContent();
    }

    [HttpGet("deliveries")]
    public async Task<IEnumerable<Delivery>> GetAllDeliveries()
    {
        return await _courierService.GetAllDeliveries();
    }

    
    [HttpGet("deliveries/courier/{courierId}")]
    public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveriesByCourierId(long courierId)
    {
        var deliveries = await _courierService.GetDeliveriesByCourierId(courierId);
        if (!deliveries.Any()) return NotFound();
        return Ok(deliveries);
    }

    [HttpGet("deliveries/order/{orderId}")]
    public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveriesByOrderId(long orderId)
    {
        var deliveries = await _courierService.GetDeliveriesByOrderId(orderId);
        if (!deliveries.Any()) return NotFound();
        return Ok(deliveries);
    }

    [HttpGet("deliveries/status/{status}")]
    public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveriesByStatus(DeliveryStatus status)
    {
        var deliveries = await _courierService.GetDeliveriesByStatus(status);
        if (!deliveries.Any()) return NotFound();
        return Ok(deliveries);
    }

    [HttpGet("deliveries/courier/{courierId}/status/{status}")]
    public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveriesByCourierIdAndStatus(long courierId, DeliveryStatus status)
    {
        var deliveries = await _courierService.GetDeliveriesByCourierIdAndStatus(courierId, status);
        if (!deliveries.Any()) return NotFound();
        return Ok(deliveries);
    }
}