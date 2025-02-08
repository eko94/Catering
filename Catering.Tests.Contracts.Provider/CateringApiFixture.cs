using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;

namespace Catering.Tests.Contracts.Provider
{
    public class CateringApiFixture : IDisposable
    {
        private readonly IHost _server;
        public Uri ServerUri { get; }

        public CateringApiFixture()
        {
            ServerUri = new Uri("http://localhost:9226");
            _server = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(ServerUri.ToString());
                    webBuilder.UseStartup<TestStartup>();
                })
                .Build();
            _server.Start();
        }

        public void Dispose()
        {
            _server.Dispose();
        }
    }
}
