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
    public class SSDHecmIndexServices : ISSDHecmIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public SSDHecmIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<SSDHecm>> SearchCheck(string search)
        {
            var SSDHecmLast = _unitOfWork.SSDHecmRepository.asQueryable();

            var SSDHecm = _unitOfWork.SSDHecmRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await SSDHecm.IsExistAsync(x => x.Cache == search);
                if (nameSearch)
                    SSDHecmLast = SSDHecmLast.Where(x => x.Cache.ToString().Contains(search));
            }
            return SSDHecmLast;
        }

    }
}
