using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Dtos;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamGBIndexServices : IRamGBIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public RamGBIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<RamGB>> SearchCheck(string search)
        {
            var RamGBLast = _unitOfWork.RamGBRepository.asQueryable();

            var RamGB = _unitOfWork.RamGBRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await RamGB.IsExistAsync(x => x.GB.ToString() == search);
                if (nameSearch)
                    RamGBLast = RamGBLast.Where(x => x.GB.ToString().Contains(search));
            }
            return RamGBLast;
        }

    }
}
