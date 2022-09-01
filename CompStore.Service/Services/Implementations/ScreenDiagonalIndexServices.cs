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

    public class ScreenDiagonalIndexServices : IScreenDiagonalIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ScreenDiagonalIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ScreenDiagonal>> SearchCheck(string search)
        {
            var ScreenDiagonalLast = _unitOfWork.ScreenDiagonalRepository.asQueryable();

            var ScreenDiagonal = _unitOfWork.ScreenDiagonalRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ScreenDiagonal.IsExistAsync(x => x.Diagonal == search);
                if (nameSearch)
                    ScreenDiagonalLast = ScreenDiagonalLast.Where(x => x.Diagonal.Contains(search));
            }
            return ScreenDiagonalLast;
        }

    }
}
