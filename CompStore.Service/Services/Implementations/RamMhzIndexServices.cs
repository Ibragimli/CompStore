using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamMhzIndexServices : IRamMhzIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public RamMhzIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<RamMhz>> SearchCheck(string search)
        {
            var RamMhzLast = _unitOfWork.RamMhzRepository.asQueryable();

            var RamMhz = _unitOfWork.RamMhzRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await RamMhz.IsExistAsync(x => x.Mhz.ToString() == search);
                if (nameSearch)
                    RamMhzLast = RamMhzLast.Where(x => x.Mhz.ToString().Contains(search));
            }
            return RamMhzLast;
        }

    }
}
