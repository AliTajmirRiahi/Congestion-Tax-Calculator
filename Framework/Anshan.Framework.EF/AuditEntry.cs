using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Anshan.Framework.EF
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }

        public string TableName { get; set; }

        public Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public Audit ToAudit()
        {
            var audit = new Audit
            {
                AggregateRootName = TableName,
                CreatedAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Values = Values.Count == 0 ? null : JsonConvert.SerializeObject(Values.Values)
            };
            return audit;
        }
    }
}