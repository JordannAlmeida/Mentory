using Domain.Interfaces.Repository;
using Domain.Models;
using Infraestructure.DataAccess;
using Infrastructure.DataAccess.Repositories.Entities.Bases;

namespace Infraestructure.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DatabasePostgresContext database): base(database)
        {

        }
    }
}
