using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ProductParametrConfiguration : IEntityTypeConfiguration<ProductParametr>
    {
        public void Configure(EntityTypeBuilder<ProductParametr> builder)
        {
            builder.Property(x => x.Bluetooth).HasDefaultValue(false);
            builder.Property(x => x.Kamera).HasDefaultValue(false);
            builder.HasOne(x => x.VideokartRam).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.VideokartRamId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProcessorModel).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ProcessorModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Teyinat).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.TeyinatId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Videokart).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.VideokartId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Color).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ColorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RamGB).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.RamGBId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RamDDR).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.RamDDRId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RamMhz).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.RamMhzId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GörüntüImkanı).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.GörüntüImkanıId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ScreenDiagonal).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ScreenDiagonalId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ScreenFrequency).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ScreenFrequencyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.OperationSystem).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.OperationSystemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProcessorCache).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ProcessorCacheId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProcessorGhz).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.ProcessorGhzId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.DaxiliYaddaş).WithMany(x => x.ProductParametrs).HasForeignKey(x => x.DaxiliYaddaşId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
