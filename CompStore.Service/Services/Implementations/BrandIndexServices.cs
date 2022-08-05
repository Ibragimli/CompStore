using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class BrandIndexServices : IBrandIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagenatedListDto<BrandListItemDto>> GetAllFiltered(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }
        //public async Task<PagenatedListDto<BrandListItemDto>> GetAllFiltered(int pageIndex, int pageSize, string? search)
        //{
        //    IEnumerable<Brand> items = await _unitOfWork.BrandRepository.GetAllPagenatedAsync(x => string.IsNullOrWhiteSpace(search) ? true : x.Name.ToLower().Contains(search), pageIndex, pageSize);
        //}
    }
}
