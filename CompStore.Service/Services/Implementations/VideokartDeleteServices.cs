using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class VideokartDeleteServices : IVideokartDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task VideokartDelete(int id)
        {
            if (!await _unitOfWork.VideokartRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Videokart tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.VideokartId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var Videokart = await _unitOfWork.VideokartRepository.GetAsync(x => x.Id == id);
            _unitOfWork.VideokartRepository.Remove(Videokart);
            await _unitOfWork.CommitAsync();
        }
    }
}
