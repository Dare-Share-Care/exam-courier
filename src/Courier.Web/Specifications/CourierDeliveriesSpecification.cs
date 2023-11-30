using Ardalis.Specification;
using Courier.Web.Entities;
using Courier.Web.Models;

namespace Courier.Web.Specifications;

public sealed class CourierDeliveriesSpecification : Specification<Delivery>
{
    public CourierDeliveriesSpecification(long courierId) =>
        this.Query.Where(delivery => delivery.CourierId == courierId);
    
    public CourierDeliveriesSpecification(long courierId, DeliveryStatus status) : this(courierId) =>
        this.Query.Where(delivery => delivery.DeliveryStatus == status);
}