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

            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new AppProfile());
            });


            //Scopes
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminAccountRepository, AdminAccountRepository>();
            services.AddScoped<IAdminLoginServices, AdminLoginServices>();
            services.AddScoped<IProductCreateRepository, ProductCreateRepository>();
            services.AddScoped<IProductCreateServices, ProductCreateServices>();
            services.AddScoped<IDaxiliYaddasRepository, DaxiliYaddasRepository>();
            services.AddScoped<ICategoryBrandIdRepository, CategoryBrandIdRepository>();
            services.AddScoped<IProductImagesRepositroy, ProductImagesRepository>();
            services.AddScoped<IProductParametrRepository, ProductParametrRepository>();
            services.AddScoped<IManageImageHelper, ManageImageHelper>();
            services.AddScoped<IProductEditServices, ProductEditServices>();

            services.AddScoped<IProductDeleteServices, ProductDeleteServices>();
            services.AddScoped<IProductDeleteRepository, ProductDeleteRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductParametrRepository, ProductParametrRepository>();
            services.AddScoped<IProductEditRepository, ProductEditRepository>();
            services.AddScoped<IImageValue, ImageValue>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<IProductDetailServices, ProductDetailServices>();




            //services.AddSingleton(provider => new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile(provider.GetService<IHelperAccessor>()));
            //}).CreateMapper());
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
