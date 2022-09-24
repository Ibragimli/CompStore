using CompStore.Core.Entites;
using CompStore.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<CategoryBrandId> CategoryBrandIds { get; set; }
        public DbSet<ProductParametr> ProductParametrs { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProcessorCache> ProcessorCache { get; set; }
        public DbSet<ProcessorGhz> ProcessorGhz { get; set; }
        public DbSet<ProcessorModel> ProcessorModel { get; set; }
        public DbSet<HDDHecm> HDDHecms { get; set; }
        public DbSet<DaxiliYaddaş> DaxiliYaddaşs { get; set; }
        public DbSet<OperationSystem> OperationSystems { get; set; }
        public DbSet<RamDDR> RamDDRs { get; set; }
        public DbSet<RamGB> RamGBs { get; set; }
        public DbSet<RamMhz> RamMhzs { get; set; }
        public DbSet<ScreenDiagonal> ScreenDiagonals { get; set; }
        public DbSet<ScreenFrequency> ScreenFrequencies { get; set; }
        public DbSet<Teyinat> Teyinats { get; set; }
        public DbSet<Videokart> Videokarts { get; set; }
        public DbSet<VideokartRam> VideokartRams { get; set; }
        public DbSet<GörüntüImkanı> GörüntüImkanıs { get; set; }
        public DbSet<SSDType> SSDTypes { get; set; }
        public DbSet<SSDHecm> SSDHecms { get; set; }
        public DbSet<ImageSetting> ImageSettings { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<MainSlider> MainSliders { get; set; }
        public DbSet<MainSpecialBox> MainSpecialBox { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
