using CompStore.Service.Dtos.Area.VideokartRams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IVideokartRamEditServices
    {
        Task VideokartRamEdit(VideokartRamEditDto VideokartRamEdit);
        Task<VideokartRamEditDto> IsExists(int id);
    }
}
