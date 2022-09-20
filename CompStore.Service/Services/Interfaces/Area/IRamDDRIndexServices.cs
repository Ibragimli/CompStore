using CompStore.Core.Entites;
using CompStore.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IRamDDRIndexServices
    {
        Task<IQueryable<RamDDR>> SearchCheck(string searchk);

    }
}
