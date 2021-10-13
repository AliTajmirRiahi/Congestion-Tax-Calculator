using Anshan.Framework.Core.Events;

namespace Anshan.Framework.EF
{
    public class EntityCreated : IEvent
    {
        public EntityCreated(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}