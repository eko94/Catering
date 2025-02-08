using System;
using System.Collections.Generic;
using System.IO;
using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using Xunit;
using Xunit.Abstractions;

namespace Catering.Tests.Contracts.Provider
{
    public class OrdenTrabajoTest : IClassFixture<CateringApiFixture>
    {
        private readonly CateringApiFixture _fixture;
        private readonly ITestOutputHelper _output;

        public OrdenTrabajoTest(CateringApiFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
        }


        [Fact]
        public void VerificarGetOrdenTrabajoById()
        {
            // Arrange
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    // NOTE: PactNet defaults to a ConsoleOutput, however
                    // xUnit 2 does not capture the console output, so this
                    // sample creates a custom xUnit outputter. You will
                    // have to do the same in xUnit projects.
                    new XunitOutput(_output),
                },
                LogLevel = PactLogLevel.Information
            };

            string pactPath = Path.Combine("..",
                "..",
                "..",
                "..",
                "..",
                "pacts",
                "Catering.Consumer-Catering.json");

            // Act // Assert
            IPactVerifier pactVerifier = new PactVerifier("Catering", config);
            pactVerifier
                .WithHttpEndpoint(_fixture.ServerUri)
                //.WithMessages(scenarios =>
                //{
                //    scenarios.Add("A request to get a catering order", () => new GetOrdenTrabajoByIdQuery(Guid.Parse("5e7d8a8f-807b-42f9-bb46-5617d835b881")));                
                //})
                .WithFileSource(new FileInfo(pactPath))
                .WithProviderStateUrl(new Uri(_fixture.ServerUri, "/provider-states"))
                .Verify();
        }

    }    
}
//https://github.com/ajaysskumar/pact-net-example/blob/master/PactNet.Provider.UnitTest/StudentControllerTest.cs