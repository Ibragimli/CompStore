using CompStore.Service.Dtos.Area.RamGbs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IRamGBEditServices
    {
        Task RamGBEdit(RamGBEditDto RamGBEdit);
        Task<RamGBEditDto> IsExists(int id);
    }
}
