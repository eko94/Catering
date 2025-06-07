using Catering.Application;
using Catering.Domain.Abstractions;
using Catering.Infrastructure;
using Joseco.Outbox.EFCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddOutboxBackgroundService<DomainEvent>();

var host = builder.Build();
host.Run();
