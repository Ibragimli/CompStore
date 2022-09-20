using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class CategoryDeleteServices : ICategoryDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CategoryDelete(int id)
        {
            if (!await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Category tapilmadi");
            }

            if (await _unitOfWork.CategoryBrandIdRepository.IsExistAsync(x => x.CategoryId == id))
            {
                throw new ItemUseException("CategoryBrand model də istifade olunur deye silmek mümkün olmadı!");
            }

            var Category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            _unitOfWork.CategoryRepository.Remove(Category);
            await _unitOfWork.CommitAsync();
        }
    }
}
