using Base.DomainImpl;
using Base.Models;
using Base.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Base
{
    public class DomainEventRepository : IDomainEventRepository
    {
        private List<DomainEventRecord> domainEvents = new List<DomainEventRecord>();

        public void Create<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
        {
            this.domainEvents.Add(new DomainEventRecord()
            {
                Created = domainEvent.Created,
                Type = domainEvent.Type,
                Args = domainEvent.Args.Select(kv => new KeyValuePair<string, string>(kv.Key, kv.Value.ToString())).ToList(),
                CorrelationID = domainEvent.CorrelationID
            });
        }

        public IEnumerable<DomainEventRecord> FindAll()
        {
            return this.domainEvents;
        }
    }
}
