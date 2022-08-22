using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.VideokartRams;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class VideokartRamEditServices : IVideokartRamEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideokartRamEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task VideokartRamEdit(VideokartRamEditDto VideokartRamEdit)
        {
            if (VideokartRamEdit.Ram == 0)
                throw new ItemNotFoundException("VideokartRam adı boş ola bilməz!");

            if (await _unitOfWork.VideokartRamsRepository.IsExistAsync(x => x.Ram == VideokartRamEdit.Ram))
                throw new ItemNameAlreadyExists("VideokartRam adı mövcuddur!");

            var lastVideokartRam = await _unitOfWork.VideokartRamsRepository.GetAsync(x => x.Id == VideokartRamEdit.Id);

            if (lastVideokartRam == null)
                throw new ItemNotFoundException("VideokartRam tapilmadı!");

            lastVideokartRam.Ram = VideokartRamEdit.Ram;

            await _unitOfWork.CommitAsync();
        }

        public async Task<VideokartRamEditDto> IsExists(int id)
        {
            var VideokartRamExist = await _unitOfWork.VideokartRamsRepository.GetAsync(x => x.Id == id);
            if (VideokartRamExist == null)
                throw new Exception("ERROR");
            VideokartRamEditDto editDto = new VideokartRamEditDto
            {
                Ram = VideokartRamExist.Ram,
                Id = VideokartRamExist.Id,
            };
            return editDto;
        }
    }
}
