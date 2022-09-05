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
    public class SSDTypeIndexServices : ISSDTypeIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public SSDTypeIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<SSDType>> SearchCheck(string search)
        {
            var SSDTypeLast = _unitOfWork.SSDTypeRepository.asQueryable();

            var SSDType = _unitOfWork.SSDTypeRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await SSDType.IsExistAsync(x => x.Type == search);
                if (nameSearch)
                    SSDTypeLast = SSDTypeLast.Where(x => x.Type.Contains(search));
            }
            return SSDTypeLast;
        }

    }
}
