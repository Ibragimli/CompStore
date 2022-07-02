using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class RamGBConfiguration : IEntityTypeConfiguration<RamGB>
    {
        public void Configure(EntityTypeBuilder<RamGB> builder)
        {
            builder.Property(x => x.GB).IsRequired();
        }
    }
}
