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
    public class ScreenFrequencyIndexServices : IScreenFrequencyIndexServices
    {

        private readonly IUnitOfWork _unitOfWork;


        public ScreenFrequencyIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ScreenFrequency>> SearchCheck(string search)
        {
            var ScreenFrequencyLast = _unitOfWork.ScreenFrequencieRepository.asQueryable();

            var ScreenFrequency = _unitOfWork.ScreenFrequencieRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ScreenFrequency.IsExistAsync(x => x.Frequency == search);
                if (nameSearch)
                    ScreenFrequencyLast = ScreenFrequencyLast.Where(x => x.Frequency.Contains(search));
            }
            return ScreenFrequencyLast;
        }

    }
}
