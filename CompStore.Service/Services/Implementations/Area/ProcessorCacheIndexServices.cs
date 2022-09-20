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
    public class ProcessorCacheIndexServices : IProcessorCacheIndexServices
    {

        private readonly IUnitOfWork _unitOfWork;


        public ProcessorCacheIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ProcessorCache>> SearchCheck(string search)
        {
            var ProcessorCacheLast = _unitOfWork.ProcessorCacheRepository.asQueryable();

            var ProcessorCache = _unitOfWork.ProcessorCacheRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ProcessorCache.IsExistAsync(x => x.Cache.ToString() == search);
                if (nameSearch)
                    ProcessorCacheLast = ProcessorCacheLast.Where(x => x.Cache.ToString().Contains(search));
            }
            return ProcessorCacheLast;
        }
    }
}
