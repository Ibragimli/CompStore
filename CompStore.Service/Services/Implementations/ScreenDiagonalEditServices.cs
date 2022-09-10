using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ScreenDiagonals;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ScreenDiagonalEditServices : IScreenDiagonalEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenDiagonalEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ScreenDiagonalEdit(ScreenDiagonalEditDto ScreenDiagonalEdit)
        {
            if (ScreenDiagonalEdit.Diagonal == null)
                throw new ItemNotFoundException("ScreenDiagonal adı boş ola bilməz!");

            if (await _unitOfWork.ScreenDiagonalRepository.IsExistAsync(x => x.Diagonal == ScreenDiagonalEdit.Diagonal && x.Id != ScreenDiagonalEdit.Id))
                throw new ItemNameAlreadyExists("ScreenDiagonal adı mövcuddur!");

            var lastScreenDiagonal = await _unitOfWork.ScreenDiagonalRepository.GetAsync(x => x.Id == ScreenDiagonalEdit.Id);

            if (lastScreenDiagonal == null)
                throw new ItemNotFoundException("ScreenDiagonal tapilmadı!");

            lastScreenDiagonal.Diagonal = ScreenDiagonalEdit.Diagonal;
            lastScreenDiagonal.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<ScreenDiagonalEditDto> IsExists(int id)
        {
            var ScreenDiagonalExist = await _unitOfWork.ScreenDiagonalRepository.GetAsync(x => x.Id == id);
            if (ScreenDiagonalExist == null)
                throw new Exception("ERROR");
            ScreenDiagonalEditDto editDto = new ScreenDiagonalEditDto
            {
                Diagonal = ScreenDiagonalExist.Diagonal,
                Id = ScreenDiagonalExist.Id,
            };
            return editDto;
        }
    }
}
