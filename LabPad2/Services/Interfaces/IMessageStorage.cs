using LabPad2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabPad2.Services.Interfaces
{
    public interface IMessageStorage
    {
        void Add(Message message);

        Message GetNextMessage();

        bool IsEmpty();
    }
}
