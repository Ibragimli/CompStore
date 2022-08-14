using CompStore.Core.Entites;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.RamGbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IRamGBIndexServices
    {
        Task<IQueryable<RamGB>> SearchCheck(string search);

    }
}
