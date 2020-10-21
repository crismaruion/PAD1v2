﻿using LabPad2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabPad2.Services
{
    public class ConnectionStorageService : IConnectionStorage
    {
        private readonly List<Connection> _connections;
        private readonly object _locker;

        public ConnectionStorageService()
        {
            _connections = new List<Connection>();
            _locker = new object();
        }

        public void Add(Connection connection)
        {
            lock (_locker)
            {
                _connections.Add(connection);
            }
        }

        public IList<Connection> GetConnectionsByTopic(string topic)
        {
            lock (_locker)
            {
                var filteredConnections = _connections.Where(x => x.Topic == topic).ToList();
                return filteredConnections;
            }
        }

        public void Remove(string address)
        {
            lock (_locker)
            {
                _connections.RemoveAll(x => x.Address == address);
            }
        }
    }
}