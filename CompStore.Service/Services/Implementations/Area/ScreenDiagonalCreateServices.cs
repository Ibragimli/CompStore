using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ScreenDiagonals;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ScreenDiagonalCreateServices : IScreenDiagonalCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenDiagonalCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(ScreenDiagonalCreateDto brandDto)
        {
            if (brandDto.ScreenDiagonal.Diagonal == null)
                throw new ItemNotFoundException("ScreenDiagonal adı boş ola bilməz!");
            if (await _unitOfWork.ScreenDiagonalRepository.IsExistAsync(x => x.Diagonal == brandDto.ScreenDiagonal.Diagonal))
                throw new ItemNameAlreadyExists("ScreenDiagonal adı mövcuddur!");

            await _unitOfWork.ScreenDiagonalRepository.InsertAsync(brandDto.ScreenDiagonal);
            await _unitOfWork.CommitAsync();
        }

    }
}
