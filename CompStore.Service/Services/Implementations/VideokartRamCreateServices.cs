using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.VideokartRams;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class VideokartRamCreateServices : IVideokartRamCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartRamCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateRam(VideokartRamCreateDto brandDto)
        {
            if (brandDto.VideokartRam.Ram == 0)
                throw new ItemNotFoundException("VideokartRam adı boş ola bilməz!");
            if (await _unitOfWork.VideokartRamsRepository.IsExistAsync(x => x.Ram == brandDto.VideokartRam.Ram))
                throw new ItemNameAlreadyExists("VideokartRam adı mövcuddur!");

            await _unitOfWork.VideokartRamsRepository.InsertAsync(brandDto.VideokartRam);
            await _unitOfWork.CommitAsync();
        }
    }
}

