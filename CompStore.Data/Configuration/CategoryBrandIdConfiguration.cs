using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class CategoryBrandIdConfiguration : IEntityTypeConfiguration<CategoryBrandId>
    {
        public void Configure(EntityTypeBuilder<CategoryBrandId> builder)
        {
            builder.HasOne(x => x.Brand).WithMany(x => x.CategoryBrandIds).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryBrandIds).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
