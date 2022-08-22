using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProcessorModelDeleteServices
    {
        Task ProcessorModelDelete(int id);

    }
}
