using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{
    public class LayoutServices : ILayoutServices
    {
        private readonly DataContext _context;

        public LayoutServices(DataContext context)
        {
            _context = context;
        }

       

        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();

        }

        public async Task<List<CategoryBrandId>> GetCategoryBrandsAsync()
        {
            return await _context.CategoryBrandIds.Include(x => x.Brand).Include(x => x.Category).ToListAsync();

        }

        public async Task<List<Category>> GetCategorysAsync()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<List<Setting>> GetSettingsAsync()
        {
            return await _context.Settings.ToListAsync();
        }
    }
}
