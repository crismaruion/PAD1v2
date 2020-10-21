using LabPad2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabPad2.Services
{
    public interface IConnectionStorage
    {
        void Add(Connection connection);

        void Remove(string address);

        IList<Connection> GetConnectionsByTopic(string topic);
    }
}
