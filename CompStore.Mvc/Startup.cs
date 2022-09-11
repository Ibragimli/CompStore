using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data;
using CompStore.Data.Repositories;
using CompStore.Data.Repository;
using CompStore.Data.UnitOfWork;
using CompStore.Mvc;
using CompStore.Mvc.ServiceExtentions;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos;
using CompStore.Service.HelperService.Implementations;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Profiles;
using CompStore.Service.Services.Implementations;
using CompStore.Service.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CompStore.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AdminLoginPostDto>());
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();

            //services.AddAutoMapper(opt =>
            //{
            //    opt.AddProfile(new AppProfile());
            //});

            //Scopes
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminAccountRepository, AdminAccountRepository>();
            services.AddScoped<IAdminLoginServices, AdminLoginServices>();
            services.AddScoped<IProductCreateServices, ProductCreateServices>();
            services.AddScoped<IDaxiliYaddasRepository, DaxiliYaddasRepository>();
            services.AddScoped<ICategoryBrandIdRepository, CategoryBrandIdRepository>();
            services.AddScoped<IProductImagesRepositroy, ProductImagesRepository>();
            services.AddScoped<IProductParametrRepository, ProductParametrRepository>();
            services.AddScoped<IManageImageHelper, ManageImageHelper>();
            services.AddScoped<IProductEditServices, ProductEditServices>();

            services.AddScoped<IProductDeleteServices, ProductDeleteServices>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductParametrRepository, ProductParametrRepository>();
            services.AddScoped<IImageValue, ImageValue>();
            services.AddScoped<IProductDetailServices, ProductDetailServices>();
            services.AddScoped<IProductIndexServices, ProductIndexServices>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandCreateServices, BrandCreateServices>();
            services.AddScoped<IBrandIndexServices, BrandIndexServices>();
            services.AddScoped<IBrandDeleteServices, BrandDeleteServices>();
            services.AddScoped<IBrandEditServices, BrandEditServices>();

            services.AddScoped<IRamDDREditServices, RamDDREditServices>();
            services.AddScoped<IRamDDRDeleteServices, RamDDRDeleteServices>();
            services.AddScoped<IRamDDRCreateServices, RamDDRCreateServices>();
            services.AddScoped<IRamDDRIndexServices, RamDDRIndexServices>();


            services.AddScoped<IRamGBEditServices, RamGBEditServices>();
            services.AddScoped<IRamGBDeleteServices, RamGBDeleteServices>();
            services.AddScoped<IRamGBCreateServices, RamGBCreateServices>();
            services.AddScoped<IRamGBIndexServices, RamGBIndexServices>();


            services.AddScoped<IRamMhzEditServices, RamMhzEditServices>();
            services.AddScoped<IRamMhzDeleteServices, RamMhzDeleteServices>();
            services.AddScoped<IRamMhzCreateServices, RamMhzCreateServices>();
            services.AddScoped<IRamMhzIndexServices, RamMhzIndexServices>();

            services.AddScoped<IGörüntüImkanıRepository, GörüntüImkanıRepository>();
            services.AddScoped<IProcessorModelRepository, ProcessorModelRepository>();
            services.AddScoped<IProcessorCacheRepository, ProcessorCacheRepository>();
            services.AddScoped<IProcessorGhzRepository, ProcessorGhzRepository>();
            services.AddScoped<IRamMhzRepository, RamMhzRepository>();
            services.AddScoped<IRamGBRepository, RamGBRepository>();
            services.AddScoped<IRamDDRRepository, RamDDRRepository>();
            services.AddScoped<ISSDHecmRepository, SSDHecmRepository>();
            services.AddScoped<ISSDTypeRepository, SSDTypeRepository>();
            services.AddScoped<IScreenDiagonalRepository, ScreenDiagonalRepository>();
            services.AddScoped<IScreenFrequencieRepository, ScreenFrequencieRepository>();

            services.AddScoped<IProcessorCacheCreateServices, ProcessorCacheCreateServices>();
            services.AddScoped<IProcessorCacheEditServices, ProcessorCacheEditServices>();
            services.AddScoped<IProcessorCacheDeleteServices, ProcessorCacheDeleteServices>();
            services.AddScoped<IProcessorCacheIndexServices, ProcessorCacheIndexServices>();


            services.AddScoped<IProcessorModelCreateServices, ProcessorModelCreateServices>();
            services.AddScoped<IProcessorModelEditServices, ProcessorModelEditServices>();
            services.AddScoped<IProcessorModelDeleteServices, ProcessorModelDeleteServices>();
            services.AddScoped<IProcessorModelIndexServices, ProcessorModelIndexServices>();


            services.AddScoped<IVideokartRamCreateServices, VideokartRamCreateServices>();
            services.AddScoped<IVideokartRamEditServices, VideokartRamEditServices>();
            services.AddScoped<IVideokartRamDeleteServices, VideokartRamDeleteServices>();
            services.AddScoped<IVideokartRamIndexServices, VideokartRamIndexServices>();


            services.AddScoped<IVideokartCreateServices, VideokartCreateServices>();
            services.AddScoped<IVideokartEditServices, VideokartEditServices>();
            services.AddScoped<IVideokartDeleteServices, VideokartDeleteServices>();
            services.AddScoped<IVideokartIndexServices, VideokartIndexServices>();


            services.AddScoped<ITeyinatCreateServices, TeyinatCreateServices>();
            services.AddScoped<ITeyinatEditServices, TeyinatEditServices>();
            services.AddScoped<ITeyinatDeleteServices, TeyinatDeleteServices>();
            services.AddScoped<ITeyinatIndexServices, TeyinatIndexServices>();


            services.AddScoped<IScreenDiagonalCreateServices, ScreenDiagonalCreateServices>();
            services.AddScoped<IScreenDiagonalEditServices, ScreenDiagonalEditServices>();
            services.AddScoped<IScreenDiagonalDeleteServices, ScreenDiagonalDeleteServices>();
            services.AddScoped<IScreenDiagonalIndexServices, ScreenDiagonalIndexServices>();

            services.AddScoped<IScreenFrequencyCreateServices, ScreenFrequencyCreateServices>();
            services.AddScoped<IScreenFrequencyEditServices, ScreenFrequencyEditServices>();
            services.AddScoped<IScreenFrequencyDeleteServices, ScreenFrequencyDeleteServices>();
            services.AddScoped<IScreenFrequencyIndexServices, ScreenFrequencyIndexServices>();

            services.AddScoped<IOperationSystemEditServices, OperationSystemEditServices>();
            services.AddScoped<IOperationSystemDeleteServices, OperationSystemDeleteServices>();
            services.AddScoped<IOperationSystemCreateServices, OperationSystemCreateServices>();
            services.AddScoped<IOperationSystemIndexServices, OperationSystemIndexServices>();

            services.AddScoped<IGörüntüImkanıEditServices, GörüntüImkanıEditServices>();
            services.AddScoped<IGörüntüImkanıDeleteServices, GörüntüImkanıDeleteServices>();
            services.AddScoped<IGörüntüImkanıCreateServices, GörüntüImkanıCreateServices>();
            services.AddScoped<IGörüntüImkanıIndexServices, GörüntüImkanıIndexServices>();

            services.AddScoped<IColorEditServices, ColorEditServices>();
            services.AddScoped<IColorDeleteServices, ColorDeleteServices>();
            services.AddScoped<IColorCreateServices, ColorCreateServices>();
            services.AddScoped<IColorIndexServices, ColorIndexServices>();

            services.AddScoped<IModelEditServices, ModelEditServices>();
            services.AddScoped<IModelDeleteServices, ModelDeleteServices>();
            services.AddScoped<IModelCreateServices, ModelCreateServices>();
            services.AddScoped<IModelIndexServices, ModelIndexServices>();

            services.AddScoped<ICategoryEditServices, CategoryEditServices>();
            services.AddScoped<ICategoryDeleteServices, CategoryDeleteServices>();
            services.AddScoped<ICategoryCreateServices, CategoryCreateServices>();
            services.AddScoped<ICategoryIndexServices, CategoryIndexServices>();

            services.AddScoped<IHDDHecmEditServices, HDDHecmEditServices>();
            services.AddScoped<IHDDHecmDeleteServices, HDDHecmDeleteServices>();
            services.AddScoped<IHDDHecmCreateServices, HDDHecmCreateServices>();
            services.AddScoped<IHDDHecmIndexServices, HDDHecmIndexServices>();

            services.AddScoped<ISSDHecmEditServices, SSDHecmEditServices>();
            services.AddScoped<ISSDHecmDeleteServices, SSDHecmDeleteServices>();
            services.AddScoped<ISSDHecmCreateServices, SSDHecmCreateServices>();
            services.AddScoped<ISSDHecmIndexServices, SSDHecmIndexServices>();

            services.AddScoped<ISSDTypeEditServices, SSDTypeEditServices>();
            services.AddScoped<ISSDTypeDeleteServices, SSDTypeDeleteServices>();
            services.AddScoped<ISSDTypeCreateServices, SSDTypeCreateServices>();
            services.AddScoped<ISSDTypeIndexServices, SSDTypeIndexServices>();

            services.AddScoped<ISettingEditServices, SettingEditServices>();
            services.AddScoped<ISettingIndexServices, SettingIndexServices>();

            services.AddScoped<ISettingImageHelper, SettingImageHelper>();



            services.AddScoped<ICategoryBrandIdEditServices, CategoryBrandIdEditServices>();
            services.AddScoped<ICategoryBrandIdDeleteServices, CategoryBrandIdDeleteServices>();
            services.AddScoped<ICategoryBrandIdCreateServices, CategoryBrandIdCreateServices>();
            services.AddScoped<ICategoryBrandIdIndexServices, CategoryBrandIdIndexServices>();

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile(provider.GetService<IHelperAccessor>()));
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.AddExceptionHandlerService();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areas",
                    "{area:exists}/{controller=dashboard}/{action=index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
