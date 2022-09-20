using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class CategoryBrandIdIndexServices : ICategoryBrandIdIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public CategoryBrandIdIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<CategoryBrandId>> SearchCheck(string search)
        {
            var CategoryBrandIdLast = _unitOfWork.CategoryBrandIdRepository.asQueryable();
            CategoryBrandIdLast = CategoryBrandIdLast.Include(x=>x.Brand).Include(x => x.Category);
            var CategoryBrandId = _unitOfWork.CategoryBrandIdRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameCategorySearch = await CategoryBrandId.IsExistAsync(x => x.Category.Name == search);
                if (nameCategorySearch)
                    CategoryBrandIdLast = CategoryBrandIdLast.Where(x => x.Category.Name.Contains(search));
              
                bool nameBrandSearch = await CategoryBrandId.IsExistAsync(x => x.Brand.Name == search);
                if (nameBrandSearch)
                    CategoryBrandIdLast = CategoryBrandIdLast.Where(x => x.Brand.Name.Contains(search));
            }
            return CategoryBrandIdLast;
        }

    }
}
