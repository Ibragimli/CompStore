using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Models;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{

    public class ModelCreateServices : IModelCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ModelCreate(ModelCreateDto brandDto)
        {
            if (brandDto.Model.Name == null)
                throw new ItemNotFoundException("Model adı boş ola bilməz!");
            if (brandDto.Model.CategoryBrandIdId == 0)
                throw new ItemNotFoundException("CategoryBrandId  boş ola bilməz!");
            if (brandDto.Model.BrandId == 0)
                throw new ItemNotFoundException("Brand adı boş ola bilməz!");

            if (await _unitOfWork.modelRepository.IsExistAsync(x => x.Name == brandDto.Model.Name))
                throw new ItemNameAlreadyExists("Model adı mövcuddur!");

            await _unitOfWork.modelRepository.InsertAsync(brandDto.Model);
            await _unitOfWork.CommitAsync();
        }

       
    }
}
