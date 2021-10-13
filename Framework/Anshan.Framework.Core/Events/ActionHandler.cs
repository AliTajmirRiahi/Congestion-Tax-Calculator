using System;

namespace Anshan.Framework.Core.Events
{
    public class ActionHandler<T> : IEventHandler<T> where T : IEvent
    {
        private readonly Action<T> _action;

        public ActionHandler(Action<T> action)
        {
            _action = action;
        }

        public void Handle(T eventToHandle)
        {
            _action(eventToHandle);
        }
    }
}