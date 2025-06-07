using Catering.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Observability
{
    internal class CorrelationIdProvider : ICorrelationIdProvider
    {
        private string _correlationId;

        public CorrelationIdProvider()
        {
            _correlationId = Guid.NewGuid().ToString();
        }
        public string GetCorrelationId()
        {
            return _correlationId;
        }

        public void SetCorrelationId(string correlationId)
        {
            _correlationId = correlationId;
        }
    }
}
