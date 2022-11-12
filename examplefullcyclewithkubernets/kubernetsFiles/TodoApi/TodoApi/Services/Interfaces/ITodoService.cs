using TodoApi.DTOs.Requests;
using TodoApi.Entities;

namespace TodoApi.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAll();

        Task<Todo> GetById(int id);

        Task<Todo> Add(CreateTodoDTO todoDto);

        Task Delete(int id);
    }
}
