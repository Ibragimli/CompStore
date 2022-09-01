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
    public class OperationSystemIndexServices : IOperationSystemIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public OperationSystemIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<OperationSystem>> SearchCheck(string search)
        {
            var OperationSystemLast = _unitOfWork.OperationSystemsRepository.asQueryable();

            var OperationSystem = _unitOfWork.OperationSystemsRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await OperationSystem.IsExistAsync(x => x.System == search);
                if (nameSearch)
                    OperationSystemLast = OperationSystemLast.Where(x => x.System.Contains(search));
            }
            return OperationSystemLast;
        }

    }
}
