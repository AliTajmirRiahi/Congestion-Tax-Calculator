using System.Collections.Generic;

namespace Anshan.Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregate
    {
        private readonly List<DomainEvent> _uncommittedChanges;

        protected AggregateRoot()
        {
            _uncommittedChanges = new List<DomainEvent>();
        }

        public void Publish(DomainEvent domainEvent)
        {
            _uncommittedChanges.Add(domainEvent);
        }

        public IReadOnlyCollection<DomainEvent> GetUncommittedChanges()
        {
            return _uncommittedChanges.AsReadOnly();
        }
    }

    public interface IAggregate
    {
        void Publish(DomainEvent domainEvent);

        IReadOnlyCollection<DomainEvent> GetUncommittedChanges();
    }
}