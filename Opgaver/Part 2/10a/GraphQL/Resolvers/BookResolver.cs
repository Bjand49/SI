using GraphQL.Models;
using GraphQL.Services;

namespace GraphQL.Resolvers
{
    public class BookResolver : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(a => a.Author)
                      .Resolve(x =>
                      {
                          var id = x.Parent<Book>().AuthorId;
                          return x.Service<AuthorService>().GetAuthor(id);
                      })
                      .Name("author")
                      .Description("The author of the book");
        }

    }

}
