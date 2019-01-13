using System;

namespace Base.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
