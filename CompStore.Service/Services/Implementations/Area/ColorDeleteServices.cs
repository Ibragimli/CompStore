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
 
    public class ColorDeleteServices : IColorDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ColorDelete(int id)
        {
            if (!await _unitOfWork.ColorRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Color tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ColorId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var Color = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ColorRepository.Remove(Color);
            await _unitOfWork.CommitAsync();
        }
    }
}
