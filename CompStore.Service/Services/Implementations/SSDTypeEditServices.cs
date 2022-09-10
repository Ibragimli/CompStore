using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.SSDTypes;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class SSDTypeEditServices : ISSDTypeEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDTypeEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task SSDTypeEdit(SSDTypeEditDto SSDTypeEdit)
        {
            if (SSDTypeEdit.Type == null)
                throw new ItemNotFoundException("SSDType adı boş ola bilməz!");

            if (await _unitOfWork.SSDTypeRepository.IsExistAsync(x => x.Type == SSDTypeEdit.Type && x.Id != SSDTypeEdit.Id))
                throw new ItemNameAlreadyExists("SSDType adı mövcuddur!");

            var lastSSDType = await _unitOfWork.SSDTypeRepository.GetAsync(x => x.Id == SSDTypeEdit.Id);

            if (lastSSDType == null)
                throw new ItemNotFoundException("SSDType tapilmadı!");

            lastSSDType.Type = SSDTypeEdit.Type;
            lastSSDType.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<SSDTypeEditDto> IsExists(int id)
        {
            var SSDTypeExist = await _unitOfWork.SSDTypeRepository.GetAsync(x => x.Id == id);
            if (SSDTypeExist == null)
                throw new Exception("ERROR");
            SSDTypeEditDto editDto = new SSDTypeEditDto
            {
                Type = SSDTypeExist.Type,
                Id = SSDTypeExist.Id,
            };
            return editDto;
        }
    }
}
