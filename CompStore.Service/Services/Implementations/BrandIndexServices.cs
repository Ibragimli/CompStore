using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IQueryable<Brand>> SearchCheck(string search)
        {
            var brandLast = _unitOfWork.BrandRepository.asQueryable();

            var brand = _unitOfWork.BrandRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await brand.IsExistAsync(x => x.Name.ToLower() == search);
                if (nameSearch)
                    brandLast = brandLast.Where(x => x.Name.ToLower().Contains(search));
            }
            return brandLast;
        }

    }
}
