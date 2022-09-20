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
    public class ProcessorModelIndexServices : IProcessorModelIndexServices
    {

        private readonly IUnitOfWork _unitOfWork;


        public ProcessorModelIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<ProcessorModel>> SearchCheck(string search)
        {
            var ProcessorModelLast = _unitOfWork.ProcessorModelRepository.asQueryable();

            var ProcessorModel = _unitOfWork.ProcessorModelRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ProcessorModel.IsExistAsync(x => x.Name.ToString() == search);
                if (nameSearch)
                    ProcessorModelLast = ProcessorModelLast.Where(x => x.Name.ToString().Contains(search));
            }
            return ProcessorModelLast;
        }
    }
}
