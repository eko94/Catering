using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Application;

namespace Catering.Tests.Application
{

    public class ExtensionsTests
    {
        [Fact]
        public void ExtensionAddAplicacionEsValido()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddAplication();
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            Assert.NotNull(serviceProvider.GetService<IComidaFactory>());
            Assert.NotNull(serviceProvider.GetService<IOrdenTrabajoFactory>());
        }
    }
}
