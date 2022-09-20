using CompStore.Core.Entites;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IBrandIndexServices
    {
        Task<IQueryable<Brand>> SearchCheck(string searchk);

    }
}
