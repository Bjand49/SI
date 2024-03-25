using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Text.Json;
using WebhookSystem.Data;
using WebhookSystem.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MapGet("/events", () =>
        {
            var list = new List<string>();
            foreach (var item in Enum.GetValues(typeof(HTTPType)))
            {
                if (item.ToString() == HTTPType.Unknown.ToString())
                {
                    continue;
                }
                list.Add(item.ToString());
            };
            return list;
        });

        app.MapGet("/ping", () =>
        {
            DataContext.SendEvent("Pings was sent", WebhookType.Ping);
        });

        app.MapGet("/users", () =>
        {
            return DataContext.GetWebhooks();
        });

        app.MapGet("/user/{id}", (Guid id) =>
        {
            return DataContext.GetWebhooks().FirstOrDefault(x => x.Id == id);
        });

        app.MapPost("/user", (UserWebhookDTO dto) =>
        {
            DataContext.SendEvent($"User {dto.Name} has subscribed to the list", WebhookType.Subscribtion);
            DataContext.SaveUsers(dto);
        });


        app.MapPut("/user", (UserWebhookDTO dto) =>
        {
            DataContext.UpdateUser(dto);
        });

        app.MapDelete("/user", (Guid id) =>
        {
            DataContext.DeleteUser(id);
        });

        app.MapDelete("/flushdb", () =>
        {
            DataContext.DeleteUsers();
        });

        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}