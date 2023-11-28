using Courier.Web.Interfaces.Repositories;

namespace Courier.Web.Data;
using Ardalis.Specification.EntityFrameworkCore;


public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public readonly CourierContext CourierContext;

    public EfRepository(CourierContext courierContext) : base(courierContext) =>
        this.CourierContext = courierContext;
}