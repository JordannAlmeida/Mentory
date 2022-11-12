namespace Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int PageNumber { get; set; }
        public float Price { get; set; }
    }
}