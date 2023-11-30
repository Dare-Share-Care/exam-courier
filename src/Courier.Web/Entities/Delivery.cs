using Courier.Web.Models;

namespace Courier.Web.Entities;

public class Delivery : BaseEntity
{
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public string DeliveryAddress { get; set; } = null!;
    public DeliveryStatus DeliveryStatus { get; set; }
    public DateTime? TimeClaimed { get; set; }
    public DateTime? TimeDelivered { get; set; }
}