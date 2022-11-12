using AutoMapper;
using Domain.Dtos.Responses.Book;

namespace WebApi.Profiles.ModelToViewModel.Book
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Domain.Models.Book, BookResponse>();
        }
    }
}
