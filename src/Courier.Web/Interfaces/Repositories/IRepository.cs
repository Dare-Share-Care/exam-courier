using Ardalis.Specification;

namespace Courier.Web.Interfaces.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    
}