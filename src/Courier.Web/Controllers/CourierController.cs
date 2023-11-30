using Microsoft.AspNetCore.Mvc;
using Courier.Web.Entities;
using Courier.Web.Interfaces.DomainServices;
using Courier.Web.Models;

namespace Courier.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;

    public CourierController(ICourierService courierService)
    {
        _courierService = courierService;
    }
    
    // POST: api/courier/claim-order
    [HttpPost("claim-order")]
    public async Task<ActionResult<Delivery>> ClaimOrder(long orderId, long courierId, string deliveryAddress)
    {
        var claimedDelivery = await _courierService.ClaimOrder(orderId, courierId, deliveryAddress);
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