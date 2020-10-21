using LabPad2.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LabPad2.Services
{
    public class MessageWorker : IHostedService
    {
        private Timer _timer;
        private const int WaitTime = 3000;
        private readonly IMessageStorage _messageStorage;
        private readonly IConnectionStorage _connectionStorage;

        public MessageWorker(IServiceScopeFactory serviceScopeFactory)
        {
            using(var scope = serviceScopeFactory.CreateScope())
            {
                _messageStorage = scope.ServiceProvider.GetRequiredService<IMessageStorage>();
                _connectionStorage = scope.ServiceProvider.GetRequiredService<IConnectionStorage>();

            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendMessages, null, 0, WaitTime);
            return Task.CompletedTask;
        }

        private void SendMessages(object state)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
