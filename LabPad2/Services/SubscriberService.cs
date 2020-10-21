using Grpc.Core;
using GrpcAgent2;
using LabPad2.Models;
using LabPad2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LabPad2.Services
{
    public class SubscriberService : Subscriber.SubscriberBase
    {
        private readonly IConnectionStorage _connectionStorage;
        public SubscriberService(IConnectionStorage connectionStorage)
        {
            _connectionStorage = connectionStorage;
        }
        public override Task<SubscribeReply> Subscribe(SubscribeRequest request, ServerCallContext context)
        {
            var connection = new Connection(request.Address, request.Topic);

            _connectionStorage.Add(connection);
            Console.WriteLine($"New client subscribed: {request.Address} : {request.Topic}");

            return Task.FromResult(new SubscribeReply()
            {
                IsSuccessed = true
            });
        }
    }
}
