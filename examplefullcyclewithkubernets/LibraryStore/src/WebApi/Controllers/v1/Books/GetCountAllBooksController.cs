using Application.Services;
using Application.UseCases;
using Application.UseCases.Books;
using Domain.Dtos.Responses.Book.GetAllBooks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.UseCases;
using WebApi.Modules.Common;

namespace WebApi.Controllers.v1.Books
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/book/")]
    public class GetCountAllBooksController : ApiController
    {
        protected IActionResult _viewModel;

        public GetCountAllBooksController(Notification notification, IHttpContextAccessor httpContextAccessor) : base(notification, httpContextAccessor)
        {
        }

        [HttpGet]
        [Route("CountAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCountAllBooksResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<IActionResult> GetAllBooks([FromServices] IGetCountAllBooksUseCase useCase, [FromQuery] decimal? price)
        {

            await useCase.executeAsync(_viewModel, price.HasValue ? price.Value : decimal.Zero);
            return _viewModel;
        }
    }
}
