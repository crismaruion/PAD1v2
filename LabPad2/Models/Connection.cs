using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabPad2.Models
{
    public class Connection
    {
        public Connection(string address, string topic)
        {
            Address = address;
            Topic = topic;
        }
        public string Address { get; }
        public string Topic { get; }
    }
}
