using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System;
using RabbitMQ.Client;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = GetMessage(args);
            var body = Encoding.UTF8.GetBytes(message);

            var factory = new ConnectionFactory()
            {
                UserName = "yurekliisa",
                Password = "123qwe",
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // not deleted queue
                    channel.QueueDeclare(
                        queue: "task_queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                      );

                    var properties = channel.CreateBasicProperties();
                    //queue won't be lost even if RabbitMQ restarts
                    properties.Persistent = true;

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "task_queue",
                        basicProperties: properties,
                        body: body
                    );
                }
            }

            Console.ReadLine();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
