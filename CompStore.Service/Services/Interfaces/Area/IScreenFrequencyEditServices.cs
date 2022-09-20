using CompStore.Service.Dtos.Area.ScreenFrequencys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IScreenFrequencyEditServices
    {
        Task ScreenFrequencyEdit(ScreenFrequencyEditDto ScreenFrequencyEdit);
        Task<ScreenFrequencyEditDto> IsExists(int id);
    }
}
