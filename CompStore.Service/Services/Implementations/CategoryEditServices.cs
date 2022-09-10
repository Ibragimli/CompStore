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
    public class CategoryEditServices : ICategoryEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task CategoryEdit(CategoryEditDto CategoryEdit)
        {
            if (CategoryEdit.Name == null)
                throw new ItemNotFoundException("Category adı boş ola bilməz!");

            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Name == CategoryEdit.Name && x.Id != CategoryEdit.Id))
                throw new ItemNameAlreadyExists("Category adı mövcuddur!");

            var lastCategory = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == CategoryEdit.Id);

            if (lastCategory == null)
                throw new ItemNotFoundException("Category tapilmadı!");

            lastCategory.Name = CategoryEdit.Name;
            lastCategory.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<CategoryEditDto> IsExists(int id)
        {
            var CategoryExist = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            if (CategoryExist == null)
                throw new Exception("ERROR");
            CategoryEditDto editDto = new CategoryEditDto
            {
                Name = CategoryExist.Name,
                Id = CategoryExist.Id,
            };
            return editDto;
        }
    }
}
