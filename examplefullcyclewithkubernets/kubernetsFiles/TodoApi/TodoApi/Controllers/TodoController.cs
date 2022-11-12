using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs.Requests;
using TodoApi.Entities;
using TodoApi.Services.Interfaces;

namespace TodoApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService service, ILogger<TodoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Todo?> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost()]
        public async Task<Todo> Add(CreateTodoDTO todo)
        {
            return await _service.Add(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}