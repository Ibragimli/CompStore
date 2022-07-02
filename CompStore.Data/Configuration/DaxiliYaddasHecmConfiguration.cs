using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class DaxiliYaddasHecmConfiguration : IEntityTypeConfiguration<DaxiliYaddasHecm>
    {
        public void Configure(EntityTypeBuilder<DaxiliYaddasHecm> builder)
        {
            builder.Property(x => x.Cache).HasMaxLength(50).IsRequired();
        }
    }
}
