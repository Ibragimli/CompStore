using CompStore.Service.Dtos.Area.OperationSystems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IOperationSystemEditServices
    {
        Task OperationSystemEdit(OperationSystemEditDto OperationSystemEdit);
        Task<OperationSystemEditDto> IsExists(int id);
    }
}
