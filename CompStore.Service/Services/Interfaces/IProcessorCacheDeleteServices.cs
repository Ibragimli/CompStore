using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProcessorCacheDeleteServices
    {
        Task ProcessorCacheDelete(int id);

    }
}
