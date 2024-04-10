// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare("fanout_exchange", ExchangeType.Fanout);

    while (true)
    {
        Console.Write("Enter message: ");
        var message = Console.ReadLine();

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish("fanout_exchange", "", null, body);
        Console.WriteLine(" [x] Sent '{0}'", message);
    }
}