using GraphQL.Models;
using GraphQL.Services;
using System;

namespace GraphQL.Resolvers
{
    public class AuthorResolver : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Books)
                      .Resolve(x =>
                      {
                        var id = x.Parent<Author>().Id;
                        return x.Service<BookService>().GetBooksByAuthorID(id);
                      })
                      .Name("books")
                      .Description("The authors books");
        }
    }
}
