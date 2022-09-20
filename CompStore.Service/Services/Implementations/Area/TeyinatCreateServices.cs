using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Teyinats;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class TeyinatCreateServices : ITeyinatCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeyinatCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTeyinat(TeyinatCreateDto TeyinatCreateDto)
        {
            if (TeyinatCreateDto.Teyinat.Type == null)
                throw new ItemNotFoundException("Teyinat adı boş ola bilməz!");
            if (await _unitOfWork.TeyinatRepository.IsExistAsync(x => x.Type == TeyinatCreateDto.Teyinat.Type))
                throw new ItemNameAlreadyExists("Teyinat adı mövcuddur!");

            await _unitOfWork.TeyinatRepository.InsertAsync(TeyinatCreateDto.Teyinat);
            await _unitOfWork.CommitAsync();
        }


    }
}
