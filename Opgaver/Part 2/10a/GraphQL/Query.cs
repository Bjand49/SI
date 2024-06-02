using GraphQL.Models;
using GraphQL.Services;
using System.Text.Json;

namespace GraphQL
{
    public class Query
    {
        public List<Book> GetBooks([Service] BookService bookService) => bookService.GetBooks();
        public Book GetBook(Guid id, [Service] BookService bookService) => bookService.GetBook(id);
        public List<Author> GetAuthors([Service] AuthorService authorService) => authorService.GetAuthors();
        public Author GetAuthor(Guid id, [Service] AuthorService authorService) => authorService.GetAuthor(id);
    }
}
