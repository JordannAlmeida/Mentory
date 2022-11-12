using Domain.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Books
{
    public interface IGetCountAllBooksUseCase
    {
        Task executeAsync(IActionResult actionResult, decimal price);
    }
}
