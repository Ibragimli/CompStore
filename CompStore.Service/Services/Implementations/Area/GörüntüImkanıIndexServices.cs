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

    public class GörüntüImkanıIndexServices : IGörüntüImkanıIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public GörüntüImkanıIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<GörüntüImkanı>> SearchCheck(string search)
        {
            var GörüntüImkanıLast = _unitOfWork.GörüntüImkanıRepository.asQueryable();

            var GörüntüImkanı = _unitOfWork.GörüntüImkanıRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await GörüntüImkanı.IsExistAsync(x => x.Capability == search);
                if (nameSearch)
                    GörüntüImkanıLast = GörüntüImkanıLast.Where(x => x.Capability.Contains(search));
            }
            return GörüntüImkanıLast;
        }

    }
}
