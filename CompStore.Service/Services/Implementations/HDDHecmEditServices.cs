using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.HDDHecms;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
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

            if (await _unitOfWork.HDDHecmsRepository.IsExistAsync(x => x.Cache == HDDHecmEdit.Cache))
                throw new ItemNameAlreadyExists("HDDHecm adı mövcuddur!");

            var lastHDDHecm = await _unitOfWork.HDDHecmsRepository.GetAsync(x => x.Id == HDDHecmEdit.Id);

            if (lastHDDHecm == null)
                throw new ItemNotFoundException("HDDHecm tapilmadı!");

            lastHDDHecm.Cache = HDDHecmEdit.Cache;

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
