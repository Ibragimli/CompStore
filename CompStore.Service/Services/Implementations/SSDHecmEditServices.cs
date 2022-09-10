using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.SSDHecms;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class SSDHecmEditServices : ISSDHecmEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDHecmEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task SSDHecmEdit(SSDHecmEditDto SSDHecmEdit)
        {
            if (SSDHecmEdit.Cache == null)
                throw new ItemNotFoundException("SSDHecm adı boş ola bilməz!");

            if (await _unitOfWork.SSDHecmRepository.IsExistAsync(x => x.Cache == SSDHecmEdit.Cache && x.Id != SSDHecmEdit.Id))
                throw new ItemNameAlreadyExists("SSDHecm adı mövcuddur!");

            var lastSSDHecm = await _unitOfWork.SSDHecmRepository.GetAsync(x => x.Id == SSDHecmEdit.Id);

            if (lastSSDHecm == null)
                throw new ItemNotFoundException("SSDHecm tapilmadı!");

            lastSSDHecm.Cache = SSDHecmEdit.Cache;
            lastSSDHecm.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<SSDHecmEditDto> IsExists(int id)
        {
            var SSDHecmExist = await _unitOfWork.SSDHecmRepository.GetAsync(x => x.Id == id);
            if (SSDHecmExist == null)
                throw new Exception("ERROR");
            SSDHecmEditDto editDto = new SSDHecmEditDto
            {
                Cache = SSDHecmExist.Cache,
                Id = SSDHecmExist.Id,
            };
            return editDto;
        }
    }
}
