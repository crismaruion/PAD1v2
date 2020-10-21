using LabPad2.Models;
using LabPad2.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabPad2.Services
{
    public class MessageStorageService : IMessageStorage
    {
        private readonly ConcurrentQueue<Message> _messagesQueue;

        public MessageStorageService()
        {
            _messagesQueue = new ConcurrentQueue<Message>();
        }
        public void Add(Message message)
        {
            _messagesQueue.Enqueue(message);
        }

        public Message GetNextMessage()
        {
            Message message; 
            _messagesQueue.TryDequeue(out message);
            return message;
        }

        public bool IsEmpty()
        {
            return _messagesQueue.IsEmpty;
        }
    }
}
