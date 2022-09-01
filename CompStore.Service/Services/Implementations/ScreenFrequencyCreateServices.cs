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
    public class ScreenFrequencyCreateServices : IScreenFrequencyCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenFrequencyCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(ScreenFrequencyCreateDto brandDto)
        {
            if (brandDto.ScreenFrequency.Frequency == null)
                throw new ItemNotFoundException("ScreenFrequency adı boş ola bilməz!");
            if (await _unitOfWork.ScreenFrequencieRepository.IsExistAsync(x => x.Frequency == brandDto.ScreenFrequency.Frequency))
                throw new ItemNameAlreadyExists("ScreenFrequency adı mövcuddur!");

            await _unitOfWork.ScreenFrequencieRepository.InsertAsync(brandDto.ScreenFrequency);
            await _unitOfWork.CommitAsync();
        }

    }
}
