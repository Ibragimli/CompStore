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

    public class ModelDeleteServices : IModelDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ModelDelete(int id)
        {
            if (!await _unitOfWork.modelRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Model tapilmadi");
            }

            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.ModelId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var Model = await _unitOfWork.modelRepository.GetAsync(x => x.Id == id);
            _unitOfWork.modelRepository.Remove(Model);
            await _unitOfWork.CommitAsync();
        }
    }
}
