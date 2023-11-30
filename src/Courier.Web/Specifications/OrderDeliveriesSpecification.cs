using Ardalis.Specification;
using Courier.Web.Entities;

namespace Courier.Web.Specifications;

public sealed class OrderDeliveriesSpecification : Specification<Delivery>
{
    public OrderDeliveriesSpecification(long orderId) =>
        this.Query.Where(delivery => delivery.OrderId == orderId);
}