using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Colors;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ColorCreateServices : IColorCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateColor(ColorCreateDto brandDto)
        {
            if (brandDto.Color.Name == null)
                throw new ItemNotFoundException("Color adı boş ola bilməz!");
            if (await _unitOfWork.ColorRepository.IsExistAsync(x => x.Name == brandDto.Color.Name))
                throw new ItemNameAlreadyExists("Color adı mövcuddur!");

            await _unitOfWork.ColorRepository.InsertAsync(brandDto.Color);
            await _unitOfWork.CommitAsync();
        }

    }
}
