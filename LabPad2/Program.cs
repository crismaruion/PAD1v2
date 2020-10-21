using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SharedSettings;

namespace LabPad2
{
    public class Program
    {
        public static object PropertiesConstants { get; private set; }

        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>()
                 .UseUrls(EndPoints.BrokerAddress)
                 .Build()
                 .Run();
        }
    }
}
