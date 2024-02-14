using FiletypeAPI;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.MapGet("/xml", () => Parser.ReadXML());
        app.MapGet("/yaml", () => Parser.ReadYAML());
        app.MapGet("/csv", () => Parser.ReadCSV());
        app.MapGet("/txt", () => Parser.ReadText());
        app.MapGet("/json", () => Parser.ReadJSON());

        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}