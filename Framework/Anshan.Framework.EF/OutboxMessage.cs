using System;

namespace Anshan.Framework.EF
{
    public class OutboxMessage
    {
        private OutboxMessage()
        {
        }

        internal OutboxMessage(DateTime eventPublishDateTime, string type, string data)
        {
            Id = Guid.NewGuid();
            EventPublishDateTime = eventPublishDateTime;
            Type = type;
            Data = data;
        }

        public Guid Id { get; set; }

        public DateTime EventPublishDateTime { get; }

        public DateTime ProcessedDate { get; private set; }

        public bool IsProcessed { get; private set; }

        public string Type { get; }

        public string Data { get; }
    }
}