using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ScreenDiagonalDeleteServices : IScreenDiagonalDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenDiagonalDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ScreenDiagonalDelete(int id)
        {
            if (!await _unitOfWork.ScreenDiagonalRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("ScreenDiagonal tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ScreenDiagonalId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ScreenDiagonal = await _unitOfWork.ScreenDiagonalRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ScreenDiagonalRepository.Remove(ScreenDiagonal);
            await _unitOfWork.CommitAsync();
        }
    }
}
