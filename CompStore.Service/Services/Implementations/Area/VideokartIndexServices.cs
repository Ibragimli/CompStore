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

    public class VideokartIndexServices : IVideokartIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public VideokartIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Videokart>> SearchCheck(string search)
        {
            var VideokartLast = _unitOfWork.VideokartRepository.asQueryable();

            var Videokart = _unitOfWork.VideokartRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Videokart.IsExistAsync(x => x.Name.ToString() == search);
                if (nameSearch)
                    VideokartLast = VideokartLast.Where(x => x.Name.ToString().Contains(search));
            }
            return VideokartLast;
        }

    }
}
