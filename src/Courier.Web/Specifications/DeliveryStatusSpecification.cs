using Ardalis.Specification;
using Courier.Web.Entities;
using Courier.Web.Models;

namespace Courier.Web.Specifications;

public sealed class DeliveryStatusSpecification : Specification<Delivery>
{
    public DeliveryStatusSpecification(DeliveryStatus status) =>
        this.Query.Where(delivery => delivery.DeliveryStatus == status);
}