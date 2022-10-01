using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.MainSpecialBoxs;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class MainSpecialBoxCreateServices : IMainSpecialBoxCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSpecialBoxImageHelper _MainSpecialBoxImageHelper;

        public MainSpecialBoxCreateServices(IUnitOfWork unitOfWork, IMainSpecialBoxImageHelper MainSpecialBoxImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSpecialBoxImageHelper = MainSpecialBoxImageHelper;
        }

        public async Task CreateMainSpecialBox(MainSpecialBoxCreateDto MainSpecialBoxDto)
        {
            if (MainSpecialBoxDto.MainSpecialBox.Title == null)
                throw new ItemNotFoundException("MainSpecialBox adı boş ola bilməz!");
           

            if (MainSpecialBoxDto.MainSpecialBox.ImageFile != null)
            {
                _MainSpecialBoxImageHelper.ImageCheck(MainSpecialBoxDto.MainSpecialBox);
                MainSpecialBoxDto.MainSpecialBox.Image = _MainSpecialBoxImageHelper.FileSave(MainSpecialBoxDto.MainSpecialBox);
            }

            await _unitOfWork.MainSpecialBoxRepository.InsertAsync(MainSpecialBoxDto.MainSpecialBox);
            await _unitOfWork.CommitAsync();
        }

    }
}
