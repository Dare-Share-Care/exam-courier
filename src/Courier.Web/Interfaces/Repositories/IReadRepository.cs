using Ardalis.Specification;

namespace Courier.Web.Interfaces.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}