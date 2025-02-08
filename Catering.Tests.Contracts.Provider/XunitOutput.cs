using PactNet.Infrastructure.Outputters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Catering.Tests.Contracts.Provider
{
    public class XunitOutput : IOutput
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initialises a new instance of the <see cref="XunitOutput"/> class.
        /// </summary>
        /// <param name="output">xUnit test output helper</param>
        public XunitOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>
        /// Write a line to the output
        /// </summary>
        /// <param name="line">Line to write</param>
        public void WriteLine(string line) => _output.WriteLine(line);
    }
}
