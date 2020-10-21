using Grpc.Net.Client;
using GrpcAgent2;
using SharedSettings;
using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Publisher app");

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(EndPoints.BrokerAddress);
            var client = new Publisher.PublisherClient(channel);

            while (true)
            {
                Console.Write("Enter topic:");
                var topic = Console.ReadLine().ToLower();

                Console.Write("Enter content: ");
                var content = Console.ReadLine();

                var request = new PublisherRequest() { Topic = topic, Content = content };

                try
                {
                    var reply = client.PublishMessage(request);
                    Console.WriteLine($"Publish Reply: {reply.IsSuccessed}");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error publish message:  { e.Message }");
                }
            }
        }
    }
}
