using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamMhzs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamMhzCreateServices : IRamMhzCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamMhzCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateMhz(RamMhzCreateDto brandDto)
        {
            if (brandDto.RamMhz.Mhz == 0)
                throw new ItemNotFoundException("RamMhz adı boş ola bilməz!");
            if (await _unitOfWork.RamMhzRepository.IsExistAsync(x => x.Mhz == brandDto.RamMhz.Mhz))
                throw new ItemNameAlreadyExists("RamMhz adı mövcuddur!");

            await _unitOfWork.RamMhzRepository.InsertAsync(brandDto.RamMhz);
            await _unitOfWork.CommitAsync();
        }

    }
}
