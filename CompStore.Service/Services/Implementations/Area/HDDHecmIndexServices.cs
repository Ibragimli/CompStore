using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class HDDHecmIndexServices : IHDDHecmIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public HDDHecmIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<HDDHecm>> SearchCheck(string search)
        {
            var HDDHecmLast = _unitOfWork.HDDHecmsRepository.asQueryable();

            var HDDHecm = _unitOfWork.HDDHecmsRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await HDDHecm.IsExistAsync(x => x.Cache == search);
                if (nameSearch)
                    HDDHecmLast = HDDHecmLast.Where(x => x.Cache.Contains(search));
            }
            return HDDHecmLast;
        }

    }
}
