using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.GörüntüImkanıs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class GörüntüImkanıEditServices : IGörüntüImkanıEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public GörüntüImkanıEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task GörüntüImkanıEdit(GörüntüImkanıEditDto GörüntüImkanıEdit)
        {
            if (GörüntüImkanıEdit.Capability == null)
                throw new ItemNotFoundException("GörüntüImkanı adı boş ola bilməz!");

            if (await _unitOfWork.GörüntüImkanıRepository.IsExistAsync(x => x.Capability == GörüntüImkanıEdit.Capability))
                throw new ItemNameAlreadyExists("GörüntüImkanı adı mövcuddur!");

            var lastGörüntüImkanı = await _unitOfWork.GörüntüImkanıRepository.GetAsync(x => x.Id == GörüntüImkanıEdit.Id);

            if (lastGörüntüImkanı == null)
                throw new ItemNotFoundException("GörüntüImkanı tapilmadı!");

            lastGörüntüImkanı.Capability = GörüntüImkanıEdit.Capability;

            await _unitOfWork.CommitAsync();
        }

        public async Task<GörüntüImkanıEditDto> IsExists(int id)
        {
            var GörüntüImkanıExist = await _unitOfWork.GörüntüImkanıRepository.GetAsync(x => x.Id == id);
            if (GörüntüImkanıExist == null)
                throw new Exception("ERROR");
            GörüntüImkanıEditDto editDto = new GörüntüImkanıEditDto
            {
                Capability = GörüntüImkanıExist.Capability,
                Id = GörüntüImkanıExist.Id,
            };
            return editDto;
        }
    }
}
