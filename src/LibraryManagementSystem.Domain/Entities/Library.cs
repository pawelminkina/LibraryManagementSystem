namespace LibraryManagementSystem.Domain.Entities
{
    public class Library
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
