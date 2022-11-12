namespace Domain.Querys
{
    public class PaginetedOrderQuery : OrderQuery
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public int PageSkip { get => (PageNumber - 1) * PageSize; }
    }
}