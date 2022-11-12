using AutoMapper;
using Domain.Dtos.Responses.Book;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Application.UseCases.Books
{
    public class GetCountAllBooksUseCase : IGetCountAllBooksUseCase
    {
        private IOutput output;
        private IBookRepository bookRepository;
        private IMapper mapper; 

        public GetCountAllBooksUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.output = new GetAllBooksPresenter();
            this.mapper = mapper;
        }

        public async Task executeAsync(IActionResult actionResult, decimal price)
        {
            try
            {
                var numberBooks = await bookRepository.CountAsync(b => ((decimal?)b.Price) <= price);
                output.Ok(actionResult, numberBooks);
            } catch (Exception e)
            {
                output.InternalServerError(actionResult, new ResponseErrorRequest("Error in request of " + this.GetType() + ": " + e.Message));
            }
        }
    }
}
