using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arta.Persistence.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.CreatedDateTimeAt);
            builder.Ignore(p => p.ModifiedAt);
            builder.Ignore(p => p.DeletedAt);
            builder.Ignore(p => p.IsDeleted);
        }
    }
}
