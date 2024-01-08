using System.Text;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessagingLayer
{
    public class RabbitMqListener : IHostedService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName = "hello";

        public RabbitMqListener()
        {
            // Initialize your RabbitMQ connection and channel
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start listening for messages in a separate thread or task
            Task.Run(() => ListenForMessages(cancellationToken));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Clean up resources when the application is stopped
            _channel.Close();
            _connection.Close();
            return Task.CompletedTask;
        }

        private void ListenForMessages(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                // Handle the received message
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received message: {message}");
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            // Wait until the cancellation token is triggered
            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    Thread.Sleep(1000); // Adjust as needed
            //}
        }
    }
}