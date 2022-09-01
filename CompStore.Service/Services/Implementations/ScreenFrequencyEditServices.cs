using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ScreenFrequencys;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ScreenFrequencyEditServices : IScreenFrequencyEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenFrequencyEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ScreenFrequencyEdit(ScreenFrequencyEditDto ScreenFrequencyEdit)
        {
            if (ScreenFrequencyEdit.Frequency == null)
                throw new ItemNotFoundException("ScreenFrequency adı boş ola bilməz!");

            if (await _unitOfWork.ScreenFrequencieRepository.IsExistAsync(x => x.Frequency == ScreenFrequencyEdit.Frequency))
                throw new ItemNameAlreadyExists("ScreenFrequency adı mövcuddur!");

            var lastScreenFrequency = await _unitOfWork.ScreenFrequencieRepository.GetAsync(x => x.Id == ScreenFrequencyEdit.Id);

            if (lastScreenFrequency == null)
                throw new ItemNotFoundException("ScreenFrequency tapilmadı!");

            lastScreenFrequency.Frequency = ScreenFrequencyEdit.Frequency;

            await _unitOfWork.CommitAsync();
        }

        public async Task<ScreenFrequencyEditDto> IsExists(int id)
        {
            var ScreenFrequencyExist = await _unitOfWork.ScreenFrequencieRepository.GetAsync(x => x.Id == id);
            if (ScreenFrequencyExist == null)
                throw new Exception("ERROR");
            ScreenFrequencyEditDto editDto = new ScreenFrequencyEditDto
            {
                Frequency = ScreenFrequencyExist.Frequency,
                Id = ScreenFrequencyExist.Id,
            };
            return editDto;
        }
    }
}
