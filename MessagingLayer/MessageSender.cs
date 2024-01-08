using System.Text;
using MessagingLayer.Models;
using RabbitMQ.Client;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Threading.Channels;

namespace MessagingLayer
{
    public class MessageSender
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName = "hello";
        public MessageSender(IOptions<RabbitMqSettings> rabbitMqSettings)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = rabbitMqSettings.Value.HostName, UserName = rabbitMqSettings.Value.UserName, Password = rabbitMqSettings.Value.Password };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
        public void CreateProjectmessage(ProjectMessageModel projectMessage) 
        {
            string message = JsonSerializer.Serialize(projectMessage);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
