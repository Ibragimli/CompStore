using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class GörüntüImkanıConfiguration : IEntityTypeConfiguration<GörüntüImkanı>
    {
        public void Configure(EntityTypeBuilder<GörüntüImkanı> builder)
        {
            builder.Property(x => x.Capability).HasMaxLength(50).IsRequired();
        }
    }
}
