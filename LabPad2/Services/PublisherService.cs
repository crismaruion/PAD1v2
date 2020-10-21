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
    public class PublisherService:Publisher.PublisherBase
    {
        private readonly IMessageStorage _messageStorage;
        public PublisherService(IMessageStorage messageStorage)
        {
            _messageStorage = messageStorage;
        }
        public override Task<PublisherReply> PublishMessage(PublisherRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Received: { request.Topic } { request.Content}");

            var message = new Message(request.Topic, request.Content);
            _messageStorage.Add(message);

            return Task.FromResult(new PublisherReply()
            {
                IsSuccessed = true
            });
        }
    }
}
