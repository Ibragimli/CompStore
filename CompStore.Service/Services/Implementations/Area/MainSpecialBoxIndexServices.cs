using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class MainSpecialBoxIndexServices : IMainSpecialBoxIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public MainSpecialBoxIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<MainSpecialBox>> SearchCheck(string search)
        {
            var MainSpecialBoxLast = _unitOfWork.MainSpecialBoxRepository.asQueryable();

            var MainSpecialBox = _unitOfWork.MainSpecialBoxRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await MainSpecialBox.IsExistAsync(x => x.Title.ToLower() == search);
                if (nameSearch)
                    MainSpecialBoxLast = MainSpecialBoxLast.Where(x => x.Title.ToLower().Contains(search));
            }
            return MainSpecialBoxLast;
        }

    }
}
