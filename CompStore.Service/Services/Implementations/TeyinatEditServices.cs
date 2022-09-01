using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Teyinats;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class TeyinatEditServices : ITeyinatEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeyinatEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task TeyinatEdit(TeyinatEditDto TeyinatEdit)
        {
            if (TeyinatEdit.Type == null)
                throw new ItemNotFoundException("Teyinat adı boş ola bilməz!");

            if (await _unitOfWork.TeyinatRepository.IsExistAsync(x => x.Type == TeyinatEdit.Type))
                throw new ItemNameAlreadyExists("Teyinat adı mövcuddur!");

            var lastTeyinat = await _unitOfWork.TeyinatRepository.GetAsync(x => x.Id == TeyinatEdit.Id);

            if (lastTeyinat == null)
                throw new ItemNotFoundException("Teyinat tapilmadı!");

            lastTeyinat.Type = TeyinatEdit.Type;

            await _unitOfWork.CommitAsync();
        }

        public async Task<TeyinatEditDto> IsExists(int id)
        {
            var TeyinatExist = await _unitOfWork.TeyinatRepository.GetAsync(x => x.Id == id);
            if (TeyinatExist == null)
                throw new Exception("ERROR");
            TeyinatEditDto editDto = new TeyinatEditDto
            {
                Type = TeyinatExist.Type,
                Id = TeyinatExist.Id,
            };
            return editDto;
        }
    }
}
