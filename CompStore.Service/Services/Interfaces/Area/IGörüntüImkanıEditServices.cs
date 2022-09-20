using CompStore.Service.Dtos.Area.GörüntüImkanıs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IGörüntüImkanıEditServices
    {
        Task GörüntüImkanıEdit(GörüntüImkanıEditDto GörüntüImkanıEdit);
        Task<GörüntüImkanıEditDto> IsExists(int id);
    }
}
