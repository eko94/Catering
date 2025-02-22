using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Abstractions
{
    public class EntityTests
    {
        [Fact]
        public void ConstructorThrowArgumentNullExceptionCuandoIdEsVacio()
        {
            // Arrange
            Guid emptyId = Guid.Empty;

            // Act
            Action act = () => new TestEntity(emptyId);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ConstructorInitializeIdAndDomainEvents()
        {
            // Arrange
            Guid validId = Guid.NewGuid();

            // Act
            var entity = new TestEntity(validId);

            // Assert
            Assert.Equal(validId, entity.Id);
            Assert.NotNull(entity.DomainEvents);
            Assert.Empty(entity.DomainEvents);
        }

        [Fact]
        public void AddDomainEvent()
        {
            // Arrange
            var entity = new TestEntity(Guid.NewGuid());
            var domainEvent = new TestDomainEvent();

            // Act
            entity.AddDomainEvent(domainEvent);

            // Assert
            Assert.Single(entity.DomainEvents);
            Assert.Contains(domainEvent, entity.DomainEvents);
        }

        [Fact]
        public void ClearDomainEvents()
        {
            // Arrange
            var entity = new TestEntity(Guid.NewGuid());
            var domainEvent = new TestDomainEvent();
            entity.AddDomainEvent(domainEvent);

            // Act
            entity.ClearDomainEvents();

            // Assert
            Assert.Empty(entity.DomainEvents);
        }

        private class TestEntity : Entity
        {
            public TestEntity(Guid id) : base(id) { }
        }

        private record TestDomainEvent : DomainEvent
        {
            public TestDomainEvent()
            {
                Id = Guid.NewGuid();
                OccuredOn = DateTime.UtcNow;
            }
        }
    }
}
