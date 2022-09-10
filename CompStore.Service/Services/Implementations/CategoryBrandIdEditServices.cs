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
    public class CategoryBrandIdEditServices : ICategoryBrandIdEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryBrandIdEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task CategoryBrandIdEdit(CategoryBrandIdEditDto CategoryBrandIdEdit)
        {
            if (CategoryBrandIdEdit.CategoryBrandId.BrandId == 0)
                throw new ItemNotFoundException("CategoryBrandId-nin Brand-i boş ola bilməz!");

            if (CategoryBrandIdEdit.CategoryBrandId.CategoryId == 0)
                throw new ItemNotFoundException("CategoryBrandId-nin Category-i boş ola bilməz!");

            bool brandId = await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id == CategoryBrandIdEdit.CategoryBrandId.BrandId);
            if (!brandId)
                throw new ItemNotFoundException("Brand tapilmadı!");

            bool categoryId = await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == CategoryBrandIdEdit.CategoryBrandId.CategoryId);
            if (!categoryId)
                throw new ItemNotFoundException("Category tapilmadı!");

            var lastCategoryBrandId = await _unitOfWork.CategoryBrandIdRepository.GetAsync(x => x.Id == CategoryBrandIdEdit.CategoryBrandId.Id);
            if (lastCategoryBrandId == null)
                throw new ItemNotFoundException("CategoryBrandId tapilmadı!");

            if (await _unitOfWork.CategoryBrandIdRepository.IsExistAsync(x => x.CategoryId == CategoryBrandIdEdit.CategoryBrandId.CategoryId && x.BrandId == CategoryBrandIdEdit.CategoryBrandId.BrandId))
                throw new ItemNameAlreadyExists("Bu CategoryBrand   mövcuddur!");


            lastCategoryBrandId.BrandId = CategoryBrandIdEdit.CategoryBrandId.BrandId;
            lastCategoryBrandId.CategoryId = CategoryBrandIdEdit.CategoryBrandId.CategoryId;
            lastCategoryBrandId.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<CategoryBrandIdEditDto> IsExists(int id)
        {
            var CategoryBrandIdExist = await _unitOfWork.CategoryBrandIdRepository.GetAsync(x => x.Id == id);
            if (CategoryBrandIdExist == null)
                throw new Exception("ERROR");
            CategoryBrandIdEditDto editDto = new CategoryBrandIdEditDto
            {
             
                CategoryBrandId = CategoryBrandIdExist,
            };
            return editDto;
        }
    }
}
