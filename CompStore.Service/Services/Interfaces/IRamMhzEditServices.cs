using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.RamMhzs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IRamMhzEditServices
    {
        Task RamMhzEdit(RamMhzEditDto RamMhzEdit);
        Task<RamMhzEditDto> IsExists(int id);
    }
}
