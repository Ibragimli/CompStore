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

    public class ProcessorGhzIndexServices : IProcessorGhzIndexServices
    {

        private readonly IUnitOfWork _unitOfWork;


        public ProcessorGhzIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ProcessorGhz>> SearchCheck(string search)
        {
            var ProcessorGhzLast = _unitOfWork.ProcessorGhzRepository.asQueryable();

            var ProcessorGhz = _unitOfWork.ProcessorGhzRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ProcessorGhz.IsExistAsync(x => x.Ghz.ToString() == search);
                if (nameSearch)
                    ProcessorGhzLast = ProcessorGhzLast.Where(x => x.Ghz.ToString().Contains(search));
            }
            return ProcessorGhzLast;
        }
    }
}
