using Ardalis.Specification;

namespace TodoApi.Repositories.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
