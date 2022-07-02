using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class VideokartConfiguration : IEntityTypeConfiguration<Videokart>
    {
        public void Configure(EntityTypeBuilder<Videokart> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
