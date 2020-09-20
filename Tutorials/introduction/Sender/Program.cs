using System;
using System.Text;
using RabbitMQ.Client;

namespace Sender
{
    // SECTION SENDER
    // NOTE Send a message to queue
    // NOTE Fistly create connection
    // NOTE Channel create model
    // NOTE Declare a queue
    // NOTE Convert object to byte array
    // NOTE Publish message to channel
    // !SECTION
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){
                UserName="yurekliisa",
                Password="123qwe",
                HostName="localhost"
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
                    string message = "Fist publish message";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "First Queue",
                        basicProperties: null,
                        body: body
                    );
                    System.Console.WriteLine("[X] Sent {0}",message);
                }
            }
            Console.ReadLine();
        }
    }
}
