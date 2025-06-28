using Catering.Application;
using Catering.Application.OrdenesTrabajo.CrearOrdenesDelDia;
using Catering.Domain.Abstractions;
using Catering.Infrastructure;
using Catering.Infrastructure.WorkerServices;
using Joseco.Outbox.EFCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, builder.Environment.ApplicationName);

builder.Services.AddTransient<CrearOrdenesDelDiaHandler>();

builder.Services.AddOutboxBackgroundService<DomainEvent>();
builder.Services.AddHostedService<CrearOrdenesDelDiaWorker>();

var host = builder.Build();
host.Run();
