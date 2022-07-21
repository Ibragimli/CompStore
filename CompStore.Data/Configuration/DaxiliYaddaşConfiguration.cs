using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class DaxiliYaddaşConfiguration : IEntityTypeConfiguration<DaxiliYaddaş>
    {
        public void Configure(EntityTypeBuilder<DaxiliYaddaş> builder)
        {
            builder.Property(x => x.IsHDD).HasDefaultValue(false);
            builder.Property(x => x.IsSSD).HasDefaultValue(false);
            builder.HasOne(x => x.HDDHecm).WithMany(x => x.DaxiliYaddaşs).HasForeignKey(x => x.HDDHecmId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.SSDType).WithMany(x => x.DaxiliYaddaşs).HasForeignKey(x => x.SSDTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(x => x.SSDHecm).WithMany(x => x.DaxiliYaddaşs).HasForeignKey(x => x.SSDHecmId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
