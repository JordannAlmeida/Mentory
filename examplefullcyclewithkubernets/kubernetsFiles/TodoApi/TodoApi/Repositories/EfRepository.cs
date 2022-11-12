using Ardalis.Specification.EntityFrameworkCore;
using TodoApi.Database;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Repositories
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public EfRepository(TodoContext dbContext) : base(dbContext)
        {
        }
    }
}
