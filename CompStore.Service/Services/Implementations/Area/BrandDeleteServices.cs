using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class BrandDeleteServices : IBrandDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandImageHelper _brandImageHelper;

        public BrandDeleteServices(IUnitOfWork unitOfWork, IBrandImageHelper brandImageHelper)
        {
            _unitOfWork = unitOfWork;
            _brandImageHelper = brandImageHelper;

        }

        public async Task BrandDelete(int id)
        {
            if (!await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Brand tapilmadi");
            }
            if (await _unitOfWork.CategoryBrandIdRepository.IsExistAsync(x => x.BrandId == id))
            {
                throw new ItemUseException("Brand məhsulda istifade olunur deye silmek mümkün olmadı!");
            }
            if (await _unitOfWork.modelRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemUseException("Brand model də istifade olunur deye silmek mümkün olmadı!");
            }

            var brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);

            _unitOfWork.BrandRepository.Remove(brand);
            if (brand.BrandImage != null)
            {
                _brandImageHelper.DeleteFile(brand.BrandImage);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}

