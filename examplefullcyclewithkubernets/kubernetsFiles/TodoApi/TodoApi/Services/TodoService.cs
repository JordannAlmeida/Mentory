using Microsoft.Extensions.Caching.Distributed;
using TodoApi.DTOs.Requests;
using TodoApi.Entities;
using TodoApi.Exceptions;
using TodoApi.Extensions;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly IDistributedCache _cache;
        private readonly IRepository<Todo> _repository;

        public TodoService(IRepository<Todo> repository, IDistributedCache cache)
        {
            _cache = cache;
            _repository = repository;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            var todos = await _cache.TryGetValueAsync<IEnumerable<Todo>>("todos");

            if (todos is not null)
                return todos;

            todos = await _repository.ListAsync();

            await _cache.SetAsync("todos", todos);

            return todos;
        }

        public async Task<Todo> GetById(int id)
        {
            var todo = await _cache.TryGetValueAsync<Todo>($"todo-{id}");
            if (todo is not null)
                return todo;

            todo = await _repository.GetByIdAsync(id);

            if (todo is null)
                throw new NotFoundException("Todo not found");

            await _cache.SetAsync($"todo-{id}", todo);

            return todo;
        }

        public async Task<Todo> Add(CreateTodoDTO todoDto)
        {
            var newTodo = await _repository.AddAsync(new Todo
            {
                Description = todoDto.Description
            });

            _cache.Remove("todos");

            return newTodo;
        }

        public async Task Delete(int id)
        {
            var todo = await GetById(id);

            await _repository.DeleteAsync(todo);

            _cache.Remove("todos");
            _cache.Remove($"todo-{id}");
        }
    }
}
