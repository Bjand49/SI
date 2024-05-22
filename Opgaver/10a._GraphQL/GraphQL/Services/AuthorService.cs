using GraphQL.Models;
using System.Text.Json;

namespace GraphQL.Services
{
    public class AuthorService
    {
        private static readonly string _authorPersistance = AppDomain.CurrentDomain.BaseDirectory + @"/Persistence/Authors.json";
        public List<Author> GetAuthors()
        {
            var authors = GetAuthorStorage();
            return authors;
        }

        public Author? GetAuthor(Guid id)
        {
            var authors = GetAuthorStorage();
            return authors.FirstOrDefault(x => x.Id == id);
        }

        private static List<Author> GetAuthorStorage()
        {
            var file = File.ReadAllText(_authorPersistance);
            var data = JsonSerializer.Deserialize<List<Author>>(file);
            return data;
        }

    }
}
