using MediatR;

namespace Catering.Domain.Abstractions
{
    public abstract record DomainEvent : INotification
    {
        public Guid Id { get; set; }
        public DateTime OccuredOn { get; set; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccuredOn = DateTime.Now;
        }
    }
}
