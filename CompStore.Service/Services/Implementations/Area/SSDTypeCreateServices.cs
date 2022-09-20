using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.SSDTypes;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class SSDTypeCreateServices : ISSDTypeCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDTypeCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateType(SSDTypeCreateDto brandDto)
        {
            if (brandDto.SSDType.Type == null)
                throw new ItemNotFoundException("SSDType adı boş ola bilməz!");
            if (await _unitOfWork.SSDTypeRepository.IsExistAsync(x => x.Type == brandDto.SSDType.Type))
                throw new ItemNameAlreadyExists("SSDType adı mövcuddur!");

            await _unitOfWork.SSDTypeRepository.InsertAsync(brandDto.SSDType);
            await _unitOfWork.CommitAsync();
        }

    }
}
