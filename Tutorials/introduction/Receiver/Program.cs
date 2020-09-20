using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receiver
{
    class Program
    {
        // SECTION  CONSUMER
        // NOTE Listening queue for messages
        // NOTE Consumer running continuously to listen for messages
        // NOTE Open a connection and a channel
        // NOTE RabbitMQ send messages async, so provide a callback function
        // !SECTION
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                UserName="yurekliisa",
                Password="123qwe",
                HostName = "localhost"
            };


            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "First Queue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    // NOTE listen channel
                    var consumer = new EventingBasicConsumer(channel);

                    // NOTE Callback function
                    consumer.Received += (ModuleHandle, eventArgs) =>
                    {
                        var body = eventArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        System.Console.WriteLine("[X] Received {0}", message);
                    };

                    // NOTE Returns ACK
                    channel.BasicConsume(
                        queue: "First Queue",
                        autoAck: true,
                        consumer: consumer
                    );

                    Console.ReadLine();

                }
            }
        }
    }
}
