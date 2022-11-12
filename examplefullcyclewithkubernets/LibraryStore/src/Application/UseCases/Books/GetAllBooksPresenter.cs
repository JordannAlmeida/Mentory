using Domain.Dtos.Responses.Book.GetAllBooks;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Application.UseCases.Books
{
    public class GetAllBooksPresenter : IOutput
    {
        public void BadRequest(IActionResult actionResult, ResponseErrorRequest responseError)
        {
            actionResult = new BadRequestObjectResult(responseError);
        }

        public void InternalServerError(IActionResult actionResult, ResponseErrorRequest responseError)
        {
            actionResult = new UnprocessableEntityObjectResult(responseError);
        }

        public void NotFound(IActionResult actionResult)
        {
            actionResult = new NotFoundObjectResult(null);
        }

        public void Ok(IActionResult actionResult, object responseBase)
        {
            actionResult = new OkObjectResult(new GetCountAllBooksResponse() with { TotalCount = (int)responseBase });
        }
    }
}
