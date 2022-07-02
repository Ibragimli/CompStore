using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ProcessorCacheConfiguration : IEntityTypeConfiguration<ProcessorCache>
    {
        public void Configure(EntityTypeBuilder<ProcessorCache> builder)
        {
            builder.Property(x => x.Cache).IsRequired();
        }
    }
}
