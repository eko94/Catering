using Catering.Application.OrdenesTrabajo.CrearOrdenesDelDia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.WorkerServices
{
    public class CrearOrdenesDelDiaWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CrearOrdenesDelDiaWorker> _logger;

        public CrearOrdenesDelDiaWorker(IServiceProvider serviceProvider, ILogger<CrearOrdenesDelDiaWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var handler = scope.ServiceProvider.GetRequiredService<CrearOrdenesDelDiaHandler>();
                        handler.Handle(new CrearOrdenesDelDiaCommand(), stoppingToken).GetAwaiter().GetResult();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear las órdenes del día.");
                }
                // Esperar un tiempo antes de la siguiente ejecución
                await Task.Delay(5000, stoppingToken);
                //await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}
