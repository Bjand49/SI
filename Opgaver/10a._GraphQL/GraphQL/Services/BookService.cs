using GraphQL.Models;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace GraphQL.Services
{
    public class BookService
    {
        private static readonly string _bookPersistance = AppDomain.CurrentDomain.BaseDirectory + @"/Persistence/Books.json";
        private static readonly string _authorPersistance = AppDomain.CurrentDomain.BaseDirectory + @"/Persistence/Authors.json";
        public List<Book> GetBooks()
        {
            var books = GetBookStorage();

            return books;
        }

        public Book? GetBook(Guid id)
        {
            var books = GetBookStorage();
            return books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooksByAuthorID(Guid authorId)
        {
            var books = GetBookStorage();
            return books.Where(x => x.AuthorId == authorId).ToList();
        }
        public SuccessMessage CreateBook(Guid authorId, string title, int? releaseYear = null)
        {
            var data = GetBookStorage();
            var book = new Book { Id = Guid.NewGuid(), AuthorId = authorId, Title = title, ReleaseYear = releaseYear };
            data.Add(book);
            var filedata = JsonSerializer.Serialize(data);
            File.WriteAllText(_bookPersistance, filedata);
            return new SuccessMessage("Book created");
        }
        public SuccessMessage UpdateBook(Guid id, Guid authorId, string title, int? releaseYear = null)
        {
            var data = GetBookStorage();
            var book = data.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return new SuccessMessage("error");
            }

            book.AuthorId = authorId;
            book.Title = title;
            book.ReleaseYear = releaseYear;

            var filedata = JsonSerializer.Serialize(data);
            File.WriteAllText(_bookPersistance, filedata);
            return new SuccessMessage("Book updated");
        }

        public SuccessMessage DeleteBook(Guid id)
        {
            var data = GetBookStorage();
            var book = data.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return new SuccessMessage("error");
            }
            data.Remove(book);
            
            var filedata = JsonSerializer.Serialize(data);
            File.WriteAllText(_bookPersistance, filedata);
            return new SuccessMessage("Book deleted");
        }
        private static List<Book> GetBookStorage()
        {
            var file = File.ReadAllText(_bookPersistance);
            var data = JsonSerializer.Deserialize<List<Book>>(file);
            return data;
        }
    }
}
