using System;

namespace EmitLogDirect
{
    // TODO : Change config 
    // TODO : Fix error on desktop
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){
                HostName="localhost"
            };

            using(var connection = factory.CreateConnection()){
                using(var channel = connection.CreateModel()){
                    channel.ExchangeDeclare(
                        exchange:"direct_logs",
                        type:"direct"
                    );
                    var severity = (args.Length > 0)? args[0] : "info";
                    var message = (args.Length > 1) ? string.Join(" ",args.Skip(1).ToArray(): "Hello World!");
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                        exchange:"direct_logs",
                        routingKey:severity,
                        basicProperties:null,
                        body:body
                    );
                    System.Console.WriteLine("[X] Sent '{0}':'{1}'",severity,message);
                }
            }
                Console.ReadLine();
        }
    }
}
