using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class GörüntüImkanıDeleteServices : IGörüntüImkanıDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public GörüntüImkanıDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GörüntüImkanıDelete(int id)
        {
            if (!await _unitOfWork.GörüntüImkanıRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("GörüntüImkanı tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.GörüntüImkanıId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var GörüntüImkanı = await _unitOfWork.GörüntüImkanıRepository.GetAsync(x => x.Id == id);
            _unitOfWork.GörüntüImkanıRepository.Remove(GörüntüImkanı);
            await _unitOfWork.CommitAsync();
        }
    }
}
