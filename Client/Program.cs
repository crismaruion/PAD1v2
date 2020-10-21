using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcAgent2;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;
using SharedSettings;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(EndPoints.ClientAddress)
                .Build();

            host.Start();
            Subscribe(host);


            Console.ReadLine();
        }

        private static void Subscribe(IWebHost host)
        {
            var channel = GrpcChannel.ForAddress(EndPoints.BrokerAddress);
            var client = new Subscriber.SubscriberClient(channel);

            var address = host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First();
            Console.WriteLine($"Subscriber listening at: {address}");

            Console.Write("Enter topic: ");
            var topic = Console.ReadLine().ToLower();

            var request = new SubscribeRequest() { Topic = topic, Address = address };

            try
            {
                var reply = client.Subscribe(request);
                Console.WriteLine($"subscribed reply: {reply.IsSuccessed}");
            } catch(Exception e)
            {
                Console.WriteLine($"Error subscribed {e.Message}");
            }
        }
    }
}
