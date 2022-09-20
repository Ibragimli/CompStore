using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.HDDHecms;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class HDDHecmEditServices : IHDDHecmEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public HDDHecmEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task HDDHecmEdit(HDDHecmEditDto HDDHecmEdit)
        {
            if (HDDHecmEdit.Cache == null)
                throw new ItemNotFoundException("HDDHecm adı boş ola bilməz!");

            if (await _unitOfWork.HDDHecmsRepository.IsExistAsync(x => x.Cache == HDDHecmEdit.Cache && x.Id != HDDHecmEdit.Id))
                throw new ItemNameAlreadyExists("HDDHecm adı mövcuddur!");

            var lastHDDHecm = await _unitOfWork.HDDHecmsRepository.GetAsync(x => x.Id == HDDHecmEdit.Id);

            if (lastHDDHecm == null)
                throw new ItemNotFoundException("HDDHecm tapilmadı!");

            lastHDDHecm.Cache = HDDHecmEdit.Cache;
            lastHDDHecm.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<HDDHecmEditDto> IsExists(int id)
        {
            var HDDHecmExist = await _unitOfWork.HDDHecmsRepository.GetAsync(x => x.Id == id);
            if (HDDHecmExist == null)
                throw new Exception("ERROR");
            HDDHecmEditDto editDto = new HDDHecmEditDto
            {
                Cache = HDDHecmExist.Cache,
                Id = HDDHecmExist.Id,
            };
            return editDto;
        }
    }
}
