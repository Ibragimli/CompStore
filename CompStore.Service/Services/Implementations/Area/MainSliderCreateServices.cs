using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.MainSliders;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class MainSliderCreateServices : IMainSliderCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSliderImageHelper _MainSliderImageHelper;

        public MainSliderCreateServices(IUnitOfWork unitOfWork, IMainSliderImageHelper MainSliderImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSliderImageHelper = MainSliderImageHelper;
        }

        public async Task CreateMainSlider(MainSliderCreateDto MainSliderDto)
        {
            if (MainSliderDto.MainSlider.Title == null)
                throw new ItemNotFoundException("Sliderın adı boş ola bilməz!");

            if (MainSliderDto.MainSlider.Description == null)
                throw new ItemNotFoundException("Sliderın təsviri boş ola bilməz!");

            if (MainSliderDto.MainSlider.ImageFile != null)
            {
                _MainSliderImageHelper.ImageCheck(MainSliderDto.MainSlider);
                MainSliderDto.MainSlider.Image = _MainSliderImageHelper.FileSave(MainSliderDto.MainSlider);
            }

            await _unitOfWork.MainSliderRepository.InsertAsync(MainSliderDto.MainSlider);
            await _unitOfWork.CommitAsync();
        }

    }
}
