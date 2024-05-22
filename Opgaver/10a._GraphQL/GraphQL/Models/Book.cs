namespace GraphQL.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int? ReleaseYear { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

    }
}
