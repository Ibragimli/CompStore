using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamGbs;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class RamGBEditServices : IRamGBEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamGBEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task RamGBEdit(RamGBEditDto RamGBEdit)
        {
            if (RamGBEdit.GB == 0)
                throw new ItemNotFoundException("RamGB adı boş ola bilməz!");

            if (await _unitOfWork.RamGBRepository.IsExistAsync(x => x.GB == RamGBEdit.GB && x.Id != RamGBEdit.Id))
                throw new ItemNameAlreadyExists("RamGB adı mövcuddur!");

            var lastRamGB = await _unitOfWork.RamGBRepository.GetAsync(x => x.Id == RamGBEdit.Id);

            if (lastRamGB == null)
                throw new ItemNotFoundException("RamGB tapilmadı!");

            lastRamGB.GB = RamGBEdit.GB;
            lastRamGB.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

       public async Task<RamGBEditDto> IsExists(int id)
        {
            var RamGBExist = await _unitOfWork.RamGBRepository.GetAsync(x => x.Id == id);
            if (RamGBExist == null)
                throw new Exception("ERROR");
            RamGBEditDto editDto = new RamGBEditDto
            {
                GB = RamGBExist.GB,
                Id = RamGBExist.Id,
            };
            return editDto;
        }
    }
}
