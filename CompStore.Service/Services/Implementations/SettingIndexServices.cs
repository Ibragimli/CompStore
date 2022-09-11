using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Settings;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class SettingIndexServices : ISettingIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public SettingIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IQueryable<Setting>> SearchCheck(string search)
        {
            var SettingLast = _unitOfWork.SettingRepository.asQueryable();

            var Setting = _unitOfWork.SettingRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Setting.IsExistAsync(x => x.Key == search);
                if (nameSearch)
                    SettingLast = SettingLast.Where(x => x.Key.Contains(search));
            }
            return SettingLast;
        }

    }
}
