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
    public class MainSliderEditServices : IMainSliderEditServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSliderImageHelper _MainSliderImageHelper;

        public MainSliderEditServices(IUnitOfWork unitOfWork, IMainSliderImageHelper MainSliderImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSliderImageHelper = MainSliderImageHelper;
        }

        public async Task MainSliderEdit(MainSliderEditDto MainSliderEdit)
        {
            if (MainSliderEdit.MainSlider.Title == null)
                throw new ItemNotFoundException("MainSlider adı boş ola bilməz!");


            var lastMainSlider = await _unitOfWork.MainSliderRepository.GetAsync(x => x.Id == MainSliderEdit.MainSlider.Id);

            if (lastMainSlider == null)
                throw new ItemNotFoundException("MainSlider tapilmadı!");

            lastMainSlider.Title = MainSliderEdit.MainSlider.Title;
            lastMainSlider.Description = MainSliderEdit.MainSlider.Description;
            if (MainSliderEdit.MainSlider.ImageFile != null)
            {
                _MainSliderImageHelper.ImageCheck(MainSliderEdit.MainSlider);
                _MainSliderImageHelper.DeleteFile(lastMainSlider.Image);
                lastMainSlider.Image = _MainSliderImageHelper.FileSave(MainSliderEdit.MainSlider);

            }
            lastMainSlider.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<MainSliderEditDto> IsExists(int id)
        {
            var MainSliderExist = await _unitOfWork.MainSliderRepository.GetAsync(x => x.Id == id);
            if (MainSliderExist == null)
                throw new Exception("ERROR");
            MainSliderEditDto editDto = new MainSliderEditDto
            {
                MainSlider = MainSliderExist,
            };
            return editDto;
        }
    }
}
