using System.Text;
using MessagingLayer.Models;
using RabbitMQ.Client;
using System.Text.Json;

namespace MessagingLayer
{
    public class MessageSender
    {
        private readonly ConnectionFactory factory;
        public MessageSender()
        {
            factory = new ConnectionFactory { HostName = "localhost" };
        }
        public void CreateProjectmessage(ProjectMessageModel projectMessage) 
        {
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(projectMessage);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
