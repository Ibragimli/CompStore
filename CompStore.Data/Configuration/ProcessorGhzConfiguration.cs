using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ProcessorGhzConfiguration : IEntityTypeConfiguration<ProcessorGhz>
    {
        public void Configure(EntityTypeBuilder<ProcessorGhz> builder)
        {
            builder.Property(x => x.Ghz).IsRequired();
        }
    }
}
