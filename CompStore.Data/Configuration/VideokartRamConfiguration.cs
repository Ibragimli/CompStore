using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class VideokartRamConfiguration : IEntityTypeConfiguration<VideokartRam>
    {
        public void Configure(EntityTypeBuilder<VideokartRam> builder)
        {
            builder.Property(x => x.Ram).IsRequired(true);
        }
    }
}
