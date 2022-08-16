using CompStore.Core.Entites;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.RamMhzs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IRamMhzIndexServices
    {
        Task<IQueryable<RamMhz>> SearchCheck(string search);

    }
}
