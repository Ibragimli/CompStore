using CompStore.Service.Dtos.Area.ProcessorCaches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProcessorCacheCreateServices
    {
        Task CreateCache(ProcessorCacheCreateDto processorCacheDto);

    }
}
