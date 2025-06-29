using Catering.Domain.OrdenesTrabajo;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PactNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catering.Tests.Contracts.Provider
{
    /// <summary>
    /// Middleware for handling provider state requests
    /// </summary>
    public class ProviderStateMiddleware
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDictionary<string, Action> _providerStates;
        private readonly RequestDelegate _next;
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepo;

        /// <summary>
        /// Initialises a new instance of the <see cref="ProviderStateMiddleware"/> class.
        /// </summary>
        /// <param name="next">Next request delegate</param>
        /// <param name="orders">Orders repository for actioning provider state requests</param>
        public ProviderStateMiddleware(RequestDelegate next, IOrdenTrabajoRepository orders)
        {
            this._next = next;
            this._ordenTrabajoRepo = orders;

            this._providerStates = new Dictionary<string, Action>
            {
                {
                    "There are a catering order", EnsureEventExistsAsync
                }
            };
        }

        /// <summary>
        /// Ensure an event exists
        /// </summary>
        /// <param name="parameters">Event parameters</param>
        /// <returns>Awaitable</returns>
        private void EnsureEventExistsAsync()
        {
            try
            {
                this._ordenTrabajoRepo.AddAsync(new OrdenTrabajo(
                Guid.Parse("5e7d8a8f-807b-42f9-bb46-5617d835b881"),
                Guid.Parse("d19a0e52-cf2a-45cb-a99f-7343afb296b4"),
                Guid.Parse("f57a6be5-585b-4b28-88df-6ed1cd2b6ef0"),
                1,
                OrdenTrabajoType.Comida,
                new List<OrdenTrabajoCliente> { new OrdenTrabajoCliente(
                    Guid.Parse("5E7D8A8F-807B-42F9-BB46-5617D835B881"),
                    Guid.Parse("9b971b55-e539-4939-9240-825a48402329"),
                    Guid.Parse("5faf7842-e7b5-4a3f-96c8-7719d01748b9"))
                }))
                .GetAwaiter()
                .GetResult();
            }            
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path
                    .Value?.StartsWith("/provider-states") ?? false)
            {
                await _next.Invoke(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.OK;

            if (context.Request.Method == HttpMethod.Post.ToString()
                && context.Request.Body != null)
            {
                string jsonRequestBody;
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    jsonRequestBody = await reader.ReadToEndAsync();
                }

                var providerState = JsonConvert.DeserializeObject<ProviderState>(jsonRequestBody);

                //A null or empty provider state key must be handled
                if (!string.IsNullOrEmpty(providerState?.State))
                {
                    _providerStates[providerState.State].Invoke();
                }

                await context.Response.WriteAsync(string.Empty);
            }
        }
    }
}
