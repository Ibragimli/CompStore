using CompStore.Service.Dtos.Area.ProcessorCaches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IProcessorCacheEditServices
    {
        Task ProcessorCacheEdit(ProcessorCacheEditDto ProcessorCacheEdit);
        Task<ProcessorCacheEditDto> IsExists(int id);
    }
}
