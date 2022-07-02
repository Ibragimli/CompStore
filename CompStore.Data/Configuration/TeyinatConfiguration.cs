using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class TeyinatConfiguration : IEntityTypeConfiguration<Teyinat>
    {
        public void Configure(EntityTypeBuilder<Teyinat> builder)
        {
            builder.Property(x => x.Type).HasMaxLength(50);
        }
    }
}
