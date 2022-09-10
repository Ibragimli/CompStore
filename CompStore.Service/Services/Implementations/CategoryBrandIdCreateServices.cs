using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.CategoryBrandIds;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{

    public class CategoryBrandIdCreateServices : ICategoryBrandIdCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryBrandIdCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(CategoryBrandIdCreateDto catBrandDto)
        {
            if (catBrandDto.CategoryBrandId.BrandId == 0)
                throw new ItemNotFoundException("CategoryBrandId-nin Brand-i boş ola bilməz!");

            if (catBrandDto.CategoryBrandId.CategoryId == 0)
                throw new ItemNotFoundException("CategoryBrandId-nin Category-i boş ola bilməz!");


            bool brandId = await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id == catBrandDto.CategoryBrandId.BrandId);
            if (!brandId)
                throw new ItemNotFoundException("Brand tapilmadı!");

            bool categoryId = await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == catBrandDto.CategoryBrandId.CategoryId);
            if (!categoryId)
                throw new ItemNotFoundException("Category tapilmadı!");

            if (await _unitOfWork.CategoryBrandIdRepository.IsExistAsync(x => x.CategoryId == catBrandDto.CategoryBrandId.CategoryId && x.BrandId == catBrandDto.CategoryBrandId.BrandId))
                throw new ItemNameAlreadyExists("Bu CategoryBrand   mövcuddur!");

            await _unitOfWork.CategoryBrandIdRepository.InsertAsync(catBrandDto.CategoryBrandId);
            await _unitOfWork.CommitAsync();
        }
    }
}
