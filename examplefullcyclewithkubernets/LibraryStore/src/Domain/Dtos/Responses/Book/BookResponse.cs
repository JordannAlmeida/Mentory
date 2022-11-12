using Domain.Dtos.Responses;

namespace Domain.Dtos.Responses.Book
{
    public class BookResponse
    {
        public string Identifier { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PageNumber { get; set; }
        public float? Price { get; set; }
    }
}
