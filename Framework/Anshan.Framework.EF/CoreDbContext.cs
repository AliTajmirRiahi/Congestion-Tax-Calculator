using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anshan.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Anshan.Framework.EF
{
    public class CoreDbContext : DbContext
    {
        //public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public CoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            var now = DateTime.Now;
            var outboxMessages = new List<OutboxMessage>();

            foreach (var entry in entities)
            {
                if (!(entry.Entity is TrackEntity entity)) continue;

                //GenerateOutboxMessages(entry, outboxMessages);

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                }
                  

                entity.ModifiedAt = now;
            }

            //this.OutboxMessages.AddRange(outboxMessages);
        }

        private static void GenerateOutboxMessages(EntityEntry entry, ICollection<OutboxMessage> outboxMessages)
        {
            if (!(entry.Entity is IAggregate aggregate)) return;

            var events = aggregate.GetUncommittedChanges();

            foreach (var domainEvent in events)
            {
                var type = domainEvent.GetType().FullName;
                var data = JsonConvert.SerializeObject(domainEvent);
                var outboxMessage = new OutboxMessage(domainEvent.EventPublishDateTime, type, data);
                outboxMessages.Add(outboxMessage);
            }
        }
    }
}