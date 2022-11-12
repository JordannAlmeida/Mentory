namespace TodoApi.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
