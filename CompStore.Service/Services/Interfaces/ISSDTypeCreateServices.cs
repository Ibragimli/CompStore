using CompStore.Service.Dtos.Area.SSDTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ISSDTypeCreateServices
    {
        Task CreateType(SSDTypeCreateDto brandDto);

    }
}
