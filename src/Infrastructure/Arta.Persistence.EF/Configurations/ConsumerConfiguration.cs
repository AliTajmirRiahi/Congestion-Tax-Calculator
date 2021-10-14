using Arta.Domain.Consumer;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arta.Persistence.EF.Configurations
{
    public class ConsumerConfiguration : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Users).WithOne(p => p.Consumer).HasForeignKey(p => p.ConsumerId);
        }
    }
}
