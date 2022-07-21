using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class SSDHecmConfiguration : IEntityTypeConfiguration<SSDHecm>
    {

        public void Configure(EntityTypeBuilder<SSDHecm> builder)
        {
            builder.Property(x => x.Cache).HasMaxLength(25);
        }
    }
}
