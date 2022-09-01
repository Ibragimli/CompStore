using CompStore.Service.Dtos.Area.ScreenFrequencys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IScreenFrequencyCreateServices
    {
        Task CreateGB(ScreenFrequencyCreateDto brandDto);

    }
}
