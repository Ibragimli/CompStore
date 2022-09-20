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

    public class CategoryBrandIdDeleteServices : ICategoryBrandIdDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryBrandIdDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CategoryBrandIdDelete(int id)
        {
            if (!await _unitOfWork.CategoryBrandIdRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("CategoryBrandId tapilmadi");
            }

            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.CategoryBrandIdId == id))
            {
                throw new ItemUseException("Product  model də istifade olunur deye silmek mümkün olmadı!");
            }
            if (await _unitOfWork.modelRepository.IsExistAsync(x => x.CategoryBrandIdId == id))
            {
                throw new ItemUseException("Model də istifade olunur deye silmek mümkün olmadı!");
            }

            var CategoryBrandId = await _unitOfWork.CategoryBrandIdRepository.GetAsync(x => x.Id == id);
            _unitOfWork.CategoryBrandIdRepository.Remove(CategoryBrandId);
            await _unitOfWork.CommitAsync();
        }
    }
}
