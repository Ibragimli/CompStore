using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.DiscountPercent).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.HasOne(x => x.CategoryBrandId).WithMany(x => x.Products).HasForeignKey(x => x.CategoryBrandIdId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProductParametr).WithMany(x => x.Products).HasForeignKey(x => x.ProductParametrId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Model).WithMany(x => x.Products).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}