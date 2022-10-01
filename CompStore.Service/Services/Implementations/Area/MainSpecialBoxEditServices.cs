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
    public class MainSpecialBoxEditServices : IMainSpecialBoxEditServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSpecialBoxImageHelper _MainSpecialBoxImageHelper;

        public MainSpecialBoxEditServices(IUnitOfWork unitOfWork, IMainSpecialBoxImageHelper MainSpecialBoxImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSpecialBoxImageHelper = MainSpecialBoxImageHelper;
        }

        public async Task MainSpecialBoxEdit(MainSpecialBoxEditDto MainSpecialBoxEdit)
        {
            if (MainSpecialBoxEdit.MainSpecialBox.Title == null)
                throw new ItemNotFoundException("MainSpecialBox adı boş ola bilməz!");

       
            var lastMainSpecialBox = await _unitOfWork.MainSpecialBoxRepository.GetAsync(x => x.Id == MainSpecialBoxEdit.MainSpecialBox.Id);

            if (lastMainSpecialBox == null)
                throw new ItemNotFoundException("MainSpecialBox tapilmadı!");

            lastMainSpecialBox.Title = MainSpecialBoxEdit.MainSpecialBox.Title;
            lastMainSpecialBox.IsFirstBox = MainSpecialBoxEdit.MainSpecialBox.IsFirstBox;
            if (MainSpecialBoxEdit.MainSpecialBox.ImageFile != null)
            {
                _MainSpecialBoxImageHelper.ImageCheck(MainSpecialBoxEdit.MainSpecialBox);
                _MainSpecialBoxImageHelper.DeleteFile(lastMainSpecialBox.Image);
                lastMainSpecialBox.Image = _MainSpecialBoxImageHelper.FileSave(MainSpecialBoxEdit.MainSpecialBox);

            }
            lastMainSpecialBox.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<MainSpecialBoxEditDto> IsExists(int id)
        {
            var MainSpecialBoxExist = await _unitOfWork.MainSpecialBoxRepository.GetAsync(x => x.Id == id);
            if (MainSpecialBoxExist == null)
                throw new Exception("ERROR");
            MainSpecialBoxEditDto editDto = new MainSpecialBoxEditDto
            {
                MainSpecialBox = MainSpecialBoxExist,
            };
            return editDto;
        }
    }
}
