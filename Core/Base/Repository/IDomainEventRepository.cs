using Base.DomainImpl;
using Base.Models;
using System.Collections.Generic;

namespace Base.Repository
{
    public interface IDomainEventRepository
    {
        void Create<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
        IEnumerable<DomainEventRecord> FindAll();
    }
}
