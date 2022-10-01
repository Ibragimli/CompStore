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

    public class MainSpecialBoxDeleteServices : IMainSpecialBoxDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainSpecialBoxImageHelper _MainSpecialBoxImageHelper;

        public MainSpecialBoxDeleteServices(IUnitOfWork unitOfWork, IMainSpecialBoxImageHelper MainSpecialBoxImageHelper)
        {
            _unitOfWork = unitOfWork;
            _MainSpecialBoxImageHelper = MainSpecialBoxImageHelper;

        }

        public async Task MainSpecialBoxDelete(int id)
        {
            if (!await _unitOfWork.MainSpecialBoxRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("MainSpecialBox tapilmadi");
            }
          

            var MainSpecialBox = await _unitOfWork.MainSpecialBoxRepository.GetAsync(x => x.Id == id);

            _unitOfWork.MainSpecialBoxRepository.Remove(MainSpecialBox);
            if (MainSpecialBox.Image != null)
            {
                _MainSpecialBoxImageHelper.DeleteFile(MainSpecialBox.Image);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
