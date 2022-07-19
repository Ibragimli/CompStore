using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasOne(x => x.CategoryBrandId).WithMany(x => x.Models).HasForeignKey(x => x.CategoryBrandIdId).OnDelete(DeleteBehavior.NoAction);
      
        }
    }
}
