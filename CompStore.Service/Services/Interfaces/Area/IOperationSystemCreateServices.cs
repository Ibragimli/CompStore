using CompStore.Service.Dtos.Area.OperationSystems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IOperationSystemCreateServices
    {
        Task CreateSystem(OperationSystemCreateDto brandDto);

    }
}
