namespace LibraryManagementSystem.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Library Library { get; set; }
        public Guid LibraryId { get; set; }
    }
}
