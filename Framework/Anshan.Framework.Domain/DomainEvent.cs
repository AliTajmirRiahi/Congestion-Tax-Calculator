using System;

namespace Anshan.Framework.Domain
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
            EventPublishDateTime = DateTime.Now;
        }

        public Guid EventId { get; }

        public DateTime EventPublishDateTime { get; }
    }
}