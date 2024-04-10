// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.HostName = "localhost";

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare("fanout_exchange", ExchangeType.Fanout);
    var queueName = channel.QueueDeclare().QueueName;
    channel.QueueBind(queueName, "fanout_exchange", "");

    Console.WriteLine(" [*] Waiting for messages.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(" [x] Received '{0}'", message);
    };

    channel.BasicConsume(queueName, true, consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
