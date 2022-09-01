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
    public class TeyinatIndexServices : ITeyinatIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public TeyinatIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IQueryable<Teyinat>> SearchCheck(string search)
        {
            var TeyinatLast = _unitOfWork.TeyinatRepository.asQueryable();

            var Teyinat = _unitOfWork.TeyinatRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Teyinat.IsExistAsync(x => x.Type.ToString() == search);
                if (nameSearch)
                    TeyinatLast = TeyinatLast.Where(x => x.Type.ToString().Contains(search));
            }
            return TeyinatLast;
        }

    }
}
