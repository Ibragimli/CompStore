using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Videokarts;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class VideokartEditServices : IVideokartEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task VideokartEdit(VideokartEditDto VideokartEdit)
        {
            if (VideokartEdit.Name == null)
                throw new ItemNotFoundException("Videokart adı boş ola bilməz!");

            if (await _unitOfWork.VideokartRepository.IsExistAsync(x => x.Name == VideokartEdit.Name))
                throw new ItemNameAlreadyExists("Videokart adı mövcuddur!");

            var lastVideokart = await _unitOfWork.VideokartRepository.GetAsync(x => x.Id == VideokartEdit.Id);

            if (lastVideokart == null)
                throw new ItemNotFoundException("Videokart tapilmadı!");

            lastVideokart.Name = VideokartEdit.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<VideokartEditDto> IsExists(int id)
        {
            var VideokartExist = await _unitOfWork.VideokartRepository.GetAsync(x => x.Id == id);
            if (VideokartExist == null)
                throw new Exception("ERROR");
            VideokartEditDto editDto = new VideokartEditDto
            {
                Name = VideokartExist.Name,
                Id = VideokartExist.Id,
            };
            return editDto;
        }
    }
}
