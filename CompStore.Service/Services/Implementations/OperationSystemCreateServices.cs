using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.OperationSystems;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class OperationSystemCreateServices : IOperationSystemCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationSystemCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateSystem(OperationSystemCreateDto brandDto)
        {
            if (brandDto.OperationSystem.System == null)
                throw new ItemNotFoundException("OperationSystem adı boş ola bilməz!");
            if (await _unitOfWork.OperationSystemsRepository.IsExistAsync(x => x.System == brandDto.OperationSystem.System))
                throw new ItemNameAlreadyExists("OperationSystem adı mövcuddur!");

            await _unitOfWork.OperationSystemsRepository.InsertAsync(brandDto.OperationSystem);
            await _unitOfWork.CommitAsync();
        }

    }
}
