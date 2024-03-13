var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.WriteLine("Enter ngrok url:");
var url = Console.ReadLine();

app.MapGet("/", async () =>
{
    var client = new HttpClient();
    client.BaseAddress = new Uri(url);
    var date = await client.GetAsync(client.BaseAddress);
    
    return $"Servertime is {await date.Content.ReadAsStringAsync()}";
});

app.Run();
