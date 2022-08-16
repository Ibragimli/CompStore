using CompStore.Service.Dtos.Area.ProcessorCaches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProcessorCacheEditServices
    {
        Task ProcessorCacheEdit(ProcessorCacheEditDto ProcessorCacheEdit);
        Task<ProcessorCacheEditDto> IsExists(int id);
    }
}
