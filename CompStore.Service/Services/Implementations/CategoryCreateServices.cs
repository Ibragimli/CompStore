using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Categorys;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class CategoryCreateServices : ICategoryCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(CategoryCreateDto brandDto)
        {
            if (brandDto.Category.Name == null)
                throw new ItemNotFoundException("Category adı boş ola bilməz!");
            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Name == brandDto.Category.Name))
                throw new ItemNameAlreadyExists("Category adı mövcuddur!");

            await _unitOfWork.CategoryRepository.InsertAsync(brandDto.Category);
            await _unitOfWork.CommitAsync();
        }

    }
}
