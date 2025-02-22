using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Abstractions
{
    public class AggregateRootTests
    {
        [Fact]
        public void AggregateRootInicializaConId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var aggregateRoot = new TestAggregateRoot(id);

            // Assert
            Assert.Equal(id, aggregateRoot.Id);
        }

        [Fact]
        public void AggregateRootInicializaSinId()
        {
            // Act
            var aggregateRoot = new TestAggregateRoot();

            // Assert
            Assert.Equal(Guid.Empty, aggregateRoot.Id);
        }

        private class TestAggregateRoot : AggregateRoot
        {
            public TestAggregateRoot(Guid id) : base(id) { }
            public TestAggregateRoot() : base() { }
        }
    }
}