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
    public class VideokartRamIndexServices : IVideokartRamIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public VideokartRamIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<VideokartRam>> SearchCheck(string search)
        {
            var VideokartRamLast = _unitOfWork.VideokartRamsRepository.asQueryable();

            var VideokartRam = _unitOfWork.VideokartRamsRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await VideokartRam.IsExistAsync(x => x.Ram.ToString() == search);
                if (nameSearch)
                    VideokartRamLast = VideokartRamLast.Where(x => x.Ram.ToString().Contains(search));
            }
            return VideokartRamLast;
        }

    }
}
