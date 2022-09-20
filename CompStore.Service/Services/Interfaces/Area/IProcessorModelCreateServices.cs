using CompStore.Service.Dtos.Area.ProcessorModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IProcessorModelCreateServices
    {
        Task CreateModel(ProcessorModelCreateDto processorModelDto);

    }
}
