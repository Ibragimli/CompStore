using CompStore.Core.Entites;
using CompStore.Service.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface ILayoutServices
    {
        public Task<List<Setting>> GetSettingsAsync();
        public Task<List<Category>> GetCategorysAsync();
        public Task<List<Brand>> GetBrandsAsync();
        public Task<List<CategoryBrandId>> GetCategoryBrandsAsync();
    }
}
