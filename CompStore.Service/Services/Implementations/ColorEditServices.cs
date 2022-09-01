using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Colors;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ColorEditServices : IColorEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ColorEdit(ColorEditDto ColorEdit)
        {
            if (ColorEdit.Name == null)
                throw new ItemNotFoundException("Color adı boş ola bilməz!");

            if (await _unitOfWork.ColorRepository.IsExistAsync(x => x.Name == ColorEdit.Name))
                throw new ItemNameAlreadyExists("Color adı mövcuddur!");

            var lastColor = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == ColorEdit.Id);

            if (lastColor == null)
                throw new ItemNotFoundException("Color tapilmadı!");

            lastColor.Name = ColorEdit.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<ColorEditDto> IsExists(int id)
        {
            var ColorExist = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == id);
            if (ColorExist == null)
                throw new Exception("ERROR");
            ColorEditDto editDto = new ColorEditDto
            {
                Name = ColorExist.Name,
                Id = ColorExist.Id,
            };
            return editDto;
        }
    }
}
