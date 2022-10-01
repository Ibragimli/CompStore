using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class MainSliderDeleteServices : IMainSliderDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSliderImageHelper _MainSliderImageHelper;

        public MainSliderDeleteServices(IUnitOfWork unitOfWork, IMainSliderImageHelper MainSliderImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSliderImageHelper = MainSliderImageHelper;

        }

        public async Task MainSliderDelete(int id)
        {
            if (!await _unitOfWork.MainSliderRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("MainSlider tapilmadi");
            }
       

            var MainSlider = await _unitOfWork.MainSliderRepository.GetAsync(x => x.Id == id);

            _unitOfWork.MainSliderRepository.Remove(MainSlider);
            if (MainSlider.Image != null)
            {
                _MainSliderImageHelper.DeleteFile(MainSlider.Image);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
