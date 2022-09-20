using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.OperationSystems;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class OperationSystemEditServices : IOperationSystemEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationSystemEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task OperationSystemEdit(OperationSystemEditDto OperationSystemEdit)
        {
            if (OperationSystemEdit.System == null)
                throw new ItemNotFoundException("OperationSystem adı boş ola bilməz!");

            if (await _unitOfWork.OperationSystemsRepository.IsExistAsync(x => x.System == OperationSystemEdit.System && x.Id != OperationSystemEdit.Id))
                throw new ItemNameAlreadyExists("OperationSystem adı mövcuddur!");

            var lastOperationSystem = await _unitOfWork.OperationSystemsRepository.GetAsync(x => x.Id == OperationSystemEdit.Id);

            if (lastOperationSystem == null)
                throw new ItemNotFoundException("OperationSystem tapilmadı!");

            lastOperationSystem.System = OperationSystemEdit.System;
            lastOperationSystem.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<OperationSystemEditDto> IsExists(int id)
        {
            var OperationSystemExist = await _unitOfWork.OperationSystemsRepository.GetAsync(x => x.Id == id);
            if (OperationSystemExist == null)
                throw new Exception("ERROR");
            OperationSystemEditDto editDto = new OperationSystemEditDto
            {
                System = OperationSystemExist.System,
                Id = OperationSystemExist.Id,
            };
            return editDto;
        }
    }
}
