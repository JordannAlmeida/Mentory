using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs.Requests
{
    public class CreateTodoDTO
    {
        [Required]
        public string Description { get; set; }
    }
}
