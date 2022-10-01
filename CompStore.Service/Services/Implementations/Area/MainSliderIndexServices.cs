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
    public class MainSliderIndexServices : IMainSliderIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainSliderIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<MainSlider>> SearchCheck(string search)
        {
            var MainSliderLast = _unitOfWork.MainSliderRepository.asQueryable();

            var MainSlider = _unitOfWork.MainSliderRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await MainSlider.IsExistAsync(x => x.Title.ToLower() == search);
                if (nameSearch)
                    MainSliderLast = MainSliderLast.Where(x => x.Title.ToLower().Contains(search));
            }
            return MainSliderLast;
        }

    }
}
