using Base.DomainImpl;

namespace Base.Domain
{
    public interface IHandles<T> where T : DomainEvent
    {
        void Handle(T args);
    }
}
