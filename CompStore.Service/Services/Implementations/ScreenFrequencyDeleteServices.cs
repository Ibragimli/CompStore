using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ScreenFrequencyDeleteServices : IScreenFrequencyDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenFrequencyDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ScreenFrequencyDelete(int id)
        {
            if (!await _unitOfWork.ScreenFrequencieRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("ScreenFrequency tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ScreenFrequencyId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ScreenFrequency = await _unitOfWork.ScreenFrequencieRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ScreenFrequencieRepository.Remove(ScreenFrequency);
            await _unitOfWork.CommitAsync();
        }
    }
}
