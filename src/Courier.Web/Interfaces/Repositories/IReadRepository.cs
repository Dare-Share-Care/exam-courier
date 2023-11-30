using Ardalis.Specification;
using Courier.Web.Entities;

namespace Courier.Web.Interfaces.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
    
}