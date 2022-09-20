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

    public class ColorIndexServices : IColorIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ColorIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Color>> SearchCheck(string search)
        {
            var ColorLast = _unitOfWork.ColorRepository.asQueryable();

            var Color = _unitOfWork.ColorRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Color.IsExistAsync(x => x.Name == search);
                if (nameSearch)
                    ColorLast = ColorLast.Where(x => x.Name.Contains(search));
            }
            return ColorLast;
        }

    }
}
