using System;

namespace DomainModel.Base
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
