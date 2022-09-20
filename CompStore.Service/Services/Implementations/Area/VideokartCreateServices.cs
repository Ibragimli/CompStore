using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Videokarts;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class VideokartCreateServices : IVideokartCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateVideokart(VideokartCreateDto brandDto)
        {
            if (brandDto.Videokart.Name == null)
                throw new ItemNotFoundException("Videokart adı boş ola bilməz!");
            if (await _unitOfWork.VideokartRepository.IsExistAsync(x => x.Name == brandDto.Videokart.Name))
                throw new ItemNameAlreadyExists("Videokart adı mövcuddur!");

            await _unitOfWork.VideokartRepository.InsertAsync(brandDto.Videokart);
            await _unitOfWork.CommitAsync();
        }

    }
}
