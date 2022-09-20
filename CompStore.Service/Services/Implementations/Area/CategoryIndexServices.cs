using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class CategoryIndexServices : ICategoryIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Category>> SearchCheck(string search)
        {
            var CategoryLast = _unitOfWork.CategoryRepository.asQueryable();

            var Category = _unitOfWork.CategoryRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Category.IsExistAsync(x => x.Name == search);
                if (nameSearch)
                    CategoryLast = CategoryLast.Where(x => x.Name.Contains(search));
            }
            return CategoryLast;
        }
    }
}
