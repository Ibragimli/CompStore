using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Models;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ModelEditServices : IModelEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ModelEdit(ModelEditDto ModelEdit)
        {

            if (await _unitOfWork.modelRepository.IsExistAsync(x => x.Name == ModelEdit.Model.Name && x.Id != ModelEdit.Model.Id))
                throw new ItemNameAlreadyExists("Model adı mövcuddur!");

            var lastModel = await _unitOfWork.modelRepository.GetAsync(x => x.Id == ModelEdit.Model.Id);

            if (lastModel == null)
                throw new ItemNotFoundException("Model tapilmadı!");

            lastModel.Name = ModelEdit.Model.Name;
            lastModel.BrandId = ModelEdit.Model.BrandId;
            lastModel.CategoryBrandIdId = ModelEdit.Model.CategoryBrandIdId;
            lastModel.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<ModelEditDto> IsExists(int id)
        {
            var ModelExist = await _unitOfWork.modelRepository.GetAsync(x => x.Id == id);

            if (ModelExist == null)
                throw new Exception("ERROR");
            ModelEditDto editDto = new ModelEditDto
            {
                Model = ModelExist,
                BrandId = ModelExist.BrandId,
                CategoryBrandIdId = ModelExist.CategoryBrandIdId

            };
            return editDto;
        }
    }
}
