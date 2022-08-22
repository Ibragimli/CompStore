using CompStore.Service.Dtos.Area.ProcessorGhzs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProcessorGhzEditServices
    {
        Task ProcessorGhzEdit(ProcessorGhzEditDto ProcessorGhzEdit);
        Task<ProcessorGhzEditDto> IsExists(int id);
    }
}
