using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ScreenDiagonalConfiguration : IEntityTypeConfiguration<ScreenDiagonal>
    {
        public void Configure(EntityTypeBuilder<ScreenDiagonal> builder)
        {
            builder.Property(x => x.Diagonal).HasMaxLength(50).IsRequired();
        }

    }
}
