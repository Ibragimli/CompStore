using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.RamDDRs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IRamDDREditServices
    {
        Task RamDDREdit(RamDDREditDto RamDDREdit);
        Task<RamDDREditDto> IsExists(int id);
    }
}
