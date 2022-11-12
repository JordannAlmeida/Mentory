namespace Domain.Querys
{
    public class PaginetedQuery
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}