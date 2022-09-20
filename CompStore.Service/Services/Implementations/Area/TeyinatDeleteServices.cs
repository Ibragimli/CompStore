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
    public class TeyinatDeleteServices : ITeyinatDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeyinatDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task TeyinatDelete(int id)
        {
            if (!await _unitOfWork.TeyinatRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Teyinat tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.TeyinatId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var Teyinat = await _unitOfWork.TeyinatRepository.GetAsync(x => x.Id == id);
            _unitOfWork.TeyinatRepository.Remove(Teyinat);
            await _unitOfWork.CommitAsync();
        }
    }
}
