using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anshan.Framework.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Arta.Persistence.EF.Configurations;
using Domain.Models.Users;
using Arta.Domain.Vehicles;

namespace Arta.Persistence.EF.Contexts
{
    public class ArtaDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArtaDbContext(DbContextOptions<ArtaDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
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

            foreach (var entry in entities)
            {
                if (!(entry.Entity is TrackEntity entity)) continue;

                if (entry.State == EntityState.Added) entity.CreatedAt = now;

                entity.ModifiedAt = now;
            }
        }
    }
}