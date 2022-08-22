using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProcessorModelDeleteServices : IProcessorModelDeleteServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProcessorModelDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessorModelDelete(int id)
        {
            if (!await _unitOfWork.ProcessorModelRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("ProcessorModel tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ProcessorModelId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ProcessorModel = await _unitOfWork.ProcessorModelRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ProcessorModelRepository.Remove(ProcessorModel);
            await _unitOfWork.CommitAsync();
        }
    }

}
