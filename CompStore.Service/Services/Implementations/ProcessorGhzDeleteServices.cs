using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProcessorGhzDeleteServices : IProcessorGhzDeleteServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProcessorGhzDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessorGhzDelete(int id)
        {
            if (!await _unitOfWork.ProcessorGhzRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("ProcessorGhz tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ProcessorGhzId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ProcessorGhz = await _unitOfWork.ProcessorGhzRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ProcessorGhzRepository.Remove(ProcessorGhz);
            await _unitOfWork.CommitAsync();
        }
    }

}
