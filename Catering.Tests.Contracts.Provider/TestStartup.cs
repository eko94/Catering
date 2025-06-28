using Catering.Domain.OrdenesTrabajo;
using Catering.Tests.Contracts.Provider.Repositories;
using Catering.WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Catering.Tests.Contracts.Provider
{
    public class TestStartup
    {

        private readonly Startup inner;
        public TestStartup(IConfiguration configuration, IHostEnvironment environment)
        {

            this.inner = new Startup(configuration, environment);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrdenTrabajoRepository, OrdenTrabajoTestRepository>();

            //services.AddRouting(options => options.LowercaseUrls = true);

            //services.AddControllers()
            //    .AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            //        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    });


            this.inner.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ProviderStateMiddleware>();
            //app.UseRouting();
            //app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            this.inner.Configure(app, env);
        }
    }
}
