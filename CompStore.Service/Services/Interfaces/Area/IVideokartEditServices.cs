using CompStore.Service.Dtos.Area.Videokarts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IVideokartEditServices
    {
        Task VideokartEdit(VideokartEditDto VideokartEdit);
        Task<VideokartEditDto> IsExists(int id);
    }
}
