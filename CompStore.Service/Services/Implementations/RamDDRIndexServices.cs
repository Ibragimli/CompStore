using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.RamDDRs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamDDRIndexServices : IRamDDRIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public RamDDRIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<RamDDR>> SearchCheck(string search)
        {
            var RamDDRLast = _unitOfWork.RamDDRRepository.asQueryable();

            var RamDDR = _unitOfWork.RamDDRRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await RamDDR.IsExistAsync(x => x.DDR.ToLower() == search);
                if (nameSearch)
                    RamDDRLast = RamDDRLast.Where(x => x.DDR.ToLower().Contains(search));
            }
            return RamDDRLast;
        }

    }
}
