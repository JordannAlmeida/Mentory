using Microsoft.AspNetCore.Mvc;
using Domain.Dtos.Responses;

namespace Application.UseCases
{
    public interface IOutput
    {
        void Ok(IActionResult actionResult, object responseBase);
        void BadRequest(IActionResult actionResult, ResponseErrorRequest responseError);
        void NotFound(IActionResult actionResult);
        void InternalServerError(IActionResult actionResult, ResponseErrorRequest responseError);
    }
}
