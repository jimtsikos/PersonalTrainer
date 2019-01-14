using Base.Domain;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Base.DomainImpl
{
    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> actions;
        private static IServiceCollection _services;

        public static void Init(IServiceCollection services)
        {
            _services = services;
        }

        //Registers a callback for the given domain event, used for testing only
        public static void Register<T>(Action<T> callback) where T : DomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : DomainEvent
        {
            if (_services != null)
            {
                _services.AddScoped<IHandles<T>, DomainEventHandle<T>>();
                ServiceProvider serviceProvider = _services.BuildServiceProvider();
                IHandles<T> handler = serviceProvider.GetService<IHandles<T>>();
                handler.Handle(args);
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            } 
        }
    }
}
