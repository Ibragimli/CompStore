using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
   public class RamDDRConfiguration : IEntityTypeConfiguration<RamDDR>
    {
        public void Configure(EntityTypeBuilder<RamDDR> builder)
        {
            builder.Property(x => x.DDR).HasMaxLength(50);

        }
    }
}
