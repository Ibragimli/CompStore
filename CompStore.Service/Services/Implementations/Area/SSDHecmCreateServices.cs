using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.SSDHecms;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class SSDHecmCreateServices : ISSDHecmCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDHecmCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(SSDHecmCreateDto brandDto)
        {
            if (brandDto.SSDHecm.Cache == null)
                throw new ItemNotFoundException("SSDHecm adı boş ola bilməz!");
            if (await _unitOfWork.SSDHecmRepository.IsExistAsync(x => x.Cache == brandDto.SSDHecm.Cache))
                throw new ItemNameAlreadyExists("SSDHecm adı mövcuddur!");

            await _unitOfWork.SSDHecmRepository.InsertAsync(brandDto.SSDHecm);
            await _unitOfWork.CommitAsync();
        }

    }
}
