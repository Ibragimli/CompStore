using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class VideokartRamDeleteServices : IVideokartRamDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartRamDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task VideokartRamDelete(int id)
        {
            if (!await _unitOfWork.VideokartRamsRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("VideokartRam tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.VideokartRamId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var VideokartRam = await _unitOfWork.VideokartRamsRepository.GetAsync(x => x.Id == id);
            _unitOfWork.VideokartRamsRepository.Remove(VideokartRam);
            await _unitOfWork.CommitAsync();
        }
    }
}

