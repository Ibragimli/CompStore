using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamDDRs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamDDREditServices : IRamDDREditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamDDREditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RamDDREdit(RamDDREditDto RamDDREdit)
        {
            if (RamDDREdit.Name == null)
                throw new ItemNotFoundException("RamDDR adı boş ola bilməz!");

            if (await _unitOfWork.RamDDRRepository.IsExistAsync(x => x.DDR.ToLower() == RamDDREdit.Name.ToLower()))
                throw new ItemNameAlreadyExists("RamDDR adı mövcuddur!");

            var lastRamDDR = await _unitOfWork.RamDDRRepository.GetAsync(x => x.Id == RamDDREdit.Id);

            if (lastRamDDR == null)
                throw new ItemNotFoundException("RamDDR tapilmadı!");

            lastRamDDR.DDR = RamDDREdit.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<RamDDREditDto> IsExists(int id)
        {
            var RamDDRExist = await _unitOfWork.RamDDRRepository.GetAsync(x => x.Id == id);
            if (RamDDRExist == null)
                throw new Exception("ERROR");
            RamDDREditDto editDto = new RamDDREditDto
            {
                Name = RamDDRExist.DDR,
                Id = RamDDRExist.Id,
            };
            return editDto;
        }
    }
}
