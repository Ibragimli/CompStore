using CompStore.Service.Dtos.Area.GörüntüImkanıs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IGörüntüImkanıCreateServices
    {
        Task CreateGB(GörüntüImkanıCreateDto brandDto);

    }
}
