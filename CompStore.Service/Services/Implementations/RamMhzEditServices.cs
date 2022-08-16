using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamMhzs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamMhzEditServices : IRamMhzEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamMhzEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task RamMhzEdit(RamMhzEditDto RamMhzEdit)
        {
            if (RamMhzEdit.Mhz == 0)
                throw new ItemNotFoundException("RamMhz adı boş ola bilməz!");

            if (await _unitOfWork.RamMhzRepository.IsExistAsync(x => x.Mhz == RamMhzEdit.Mhz))
                throw new ItemNameAlreadyExists("RamMhz adı mövcuddur!");

            var lastRamMhz = await _unitOfWork.RamMhzRepository.GetAsync(x => x.Id == RamMhzEdit.Id);

            if (lastRamMhz == null)
                throw new ItemNotFoundException("RamMhz tapilmadı!");

            lastRamMhz.Mhz = RamMhzEdit.Mhz;

            await _unitOfWork.CommitAsync();
        }

        public async Task<RamMhzEditDto> IsExists(int id)
        {
            var RamMhzExist = await _unitOfWork.RamMhzRepository.GetAsync(x => x.Id == id);
            if (RamMhzExist == null)
                throw new Exception("ERROR");
            RamMhzEditDto editDto = new RamMhzEditDto
            {
                Mhz = RamMhzExist.Mhz,
                Id = RamMhzExist.Id,
            };
            return editDto;
        }
    }
}
