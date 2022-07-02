using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class RamMhzConfiguration : IEntityTypeConfiguration<RamMhz>
    {
        public void Configure(EntityTypeBuilder<RamMhz> builder)
        {
            builder.Property(x => x.Mhz).IsRequired(true);
        }
    }
}
