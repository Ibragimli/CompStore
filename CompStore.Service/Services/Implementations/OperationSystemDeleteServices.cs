using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class OperationSystemDeleteServices : IOperationSystemDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationSystemDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OperationSystemDelete(int id)
        {
            if (!await _unitOfWork.OperationSystemsRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("OperationSystem tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.OperationSystemId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var OperationSystem = await _unitOfWork.OperationSystemsRepository.GetAsync(x => x.Id == id);
            _unitOfWork.OperationSystemsRepository.Remove(OperationSystem);
            await _unitOfWork.CommitAsync();
        }
    }
}

