using System;

namespace DomainModel.Base
{
    public interface IAggregateRoot<TId>
    {
        TId Id { get; }
    }
}
