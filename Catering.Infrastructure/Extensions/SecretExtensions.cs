﻿using Joseco.Communication.External.RabbitMQ.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nur.Store2025.Observability.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Extensions
{
    public static class SecretExtensions
    {
        private const string JeagerSettingsSecretName = "JaegerSettings";
        private const string JwtOptionsSecretName = "JwtOptions";
        private const string RabbitMqSettingsSecretName = "RabbitMqSettings";

        public static IServiceCollection AddSecrets(this IServiceCollection services, IConfiguration configuration)//, IHostEnvironment environment)
        {
            //bool useSecretManager = configuration.GetValue<bool>("UseSecretManager", false);
            //if (environment.IsDevelopment() && !useSecretManager)
            //{                

            configuration
                .LoadAndRegister<RabbitMqSettings>(services, RabbitMqSettingsSecretName)
                .LoadAndRegister<JeagerSettings>(services, JeagerSettingsSecretName);

            return services;
            //}

            //string? vaultUrl = Environment.GetEnvironmentVariable("VAULT_URL");
            //string? vaultToken = Environment.GetEnvironmentVariable("VAULT_TOKEN");

            //if (string.IsNullOrEmpty(vaultUrl) || string.IsNullOrEmpty(vaultToken))
            //{
            //    throw new InvalidOperationException("Vault URL or Token is not set in environment variables.");
            //}

            //var settings = new VaultSettings()
            //{
            //    VaultUrl = vaultUrl,
            //    VaultToken = vaultToken
            //};

            //services.AddHashicorpVault(settings)
            //    .LoadSecretsFromVault();

            //return services;
        }

        private static IConfiguration LoadAndRegister<T>(this IConfiguration configuration, IServiceCollection services,
            string secretName) where T : class, new()
        {
            T secret = Activator.CreateInstance<T>();
            configuration.Bind(secretName, secret);
            services.AddSingleton<T>(secret);
            return configuration;
        }
    }
}
