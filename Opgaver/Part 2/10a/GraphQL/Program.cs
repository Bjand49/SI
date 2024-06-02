using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<AuthorService>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookResolver>()
    .AddType<AuthorResolver>()
    .AddMutationType<Mutation>()
;
var app = builder.Build();
app.MapGraphQL();

app.Run();
