using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ModelIndexServices : IModelIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ModelIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Model>> SearchCheck(string search)
        {
            var ModelLast = _unitOfWork.modelRepository.asQueryable();
            ModelLast = ModelLast.Include(x => x.CategoryBrandId.Brand).Include(x => x.CategoryBrandId.Category).Include(x => x.Brand);
            var Model = _unitOfWork.modelRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await Model.IsExistAsync(x => x.Name == search);
                if (nameSearch)
                    ModelLast = ModelLast.Where(x => x.Name.Contains(search));
            }
            return ModelLast;
        }

    }
}
