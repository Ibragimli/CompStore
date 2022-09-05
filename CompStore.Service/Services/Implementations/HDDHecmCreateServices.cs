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
    public class HDDHecmCreateServices : IHDDHecmCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public HDDHecmCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(HDDHecmCreateDto brandDto)
        {
            if (brandDto.HDDHecm.Cache == null)
                throw new ItemNotFoundException("HDDHecm adı boş ola bilməz!");
            if (await _unitOfWork.HDDHecmsRepository.IsExistAsync(x => x.Cache == brandDto.HDDHecm.Cache))
                throw new ItemNameAlreadyExists("HDDHecm adı mövcuddur!");

            await _unitOfWork.HDDHecmsRepository.InsertAsync(brandDto.HDDHecm);
            await _unitOfWork.CommitAsync();
        }

    }
}
