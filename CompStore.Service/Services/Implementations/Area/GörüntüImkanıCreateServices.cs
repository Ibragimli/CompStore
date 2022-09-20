using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.GörüntüImkanıs;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class GörüntüImkanıCreateServices : IGörüntüImkanıCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public GörüntüImkanıCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(GörüntüImkanıCreateDto brandDto)
        {
            if (brandDto.GörüntüImkanı.Capability == null)
                throw new ItemNotFoundException("GörüntüImkanı adı boş ola bilməz!");
            if (await _unitOfWork.GörüntüImkanıRepository.IsExistAsync(x => x.Capability == brandDto.GörüntüImkanı.Capability))
                throw new ItemNameAlreadyExists("GörüntüImkanı adı mövcuddur!");

            await _unitOfWork.GörüntüImkanıRepository.InsertAsync(brandDto.GörüntüImkanı);
            await _unitOfWork.CommitAsync();
        }

    }
}
