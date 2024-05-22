using GraphQL.Models;
using GraphQL.Services;
using System.Text.Json;

namespace GraphQL
{
    public class Mutation
    {
        public SuccessMessage CreateBook([Service] BookService bookService, [ID] Guid authorId, string title, int? releaseYear = null) => 
            bookService.CreateBook(authorId, title, releaseYear);
        public SuccessMessage UpdateBook([Service] BookService bookService, [ID] Guid id, [ID] Guid authorId, string title, int? releaseYear = null) =>
    bookService.UpdateBook(id,authorId, title, releaseYear);
        public SuccessMessage DeleteBook([Service] BookService bookService, [ID] Guid id) => bookService.DeleteBook(id);


    }
}
