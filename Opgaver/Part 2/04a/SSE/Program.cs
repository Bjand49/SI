using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options
        => options.AddPolicy("cors", policyBuilder =>
            {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyOrigin();
            }));

var app = builder.Build();
app.UseStaticFiles();
app.UseCors("cors");

app.MapGet("/sse",async context =>
    {
        var cancellationToken = context.RequestAborted;
        context.Response.Headers.Add("Content-Type", "text/event-stream");

        while (!cancellationToken.IsCancellationRequested)
        {
            await context.Response.WriteAsync($"data: {DateTimeOffset.Now}\n\n");
            await context.Response.Body.FlushAsync(cancellationToken); // Ensure the message is sent immediately
            await Task.Delay(500, cancellationToken);
        }
    });

app.Run();