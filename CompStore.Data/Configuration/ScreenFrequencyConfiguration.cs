using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ScreenFrequencyConfiguration : IEntityTypeConfiguration<ScreenFrequency>
    {
        public void Configure(EntityTypeBuilder<ScreenFrequency> builder)
        {
            builder.Property(x => x.Frequency).HasMaxLength(50).IsRequired();
        }
    }
}
