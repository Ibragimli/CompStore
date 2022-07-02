using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class OperationSystemConfiguration : IEntityTypeConfiguration<OperationSystem>
    {
        public void Configure(EntityTypeBuilder<OperationSystem> builder)
        {
            builder.Property(x => x.System).HasMaxLength(60).IsRequired();
        }
    }
}
