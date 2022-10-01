using CompStore.Service.Dtos.Area.MainSpecialBoxs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IMainSpecialBoxEditServices
    {
        Task MainSpecialBoxEdit(MainSpecialBoxEditDto MainSpecialBoxEdit);
        Task<MainSpecialBoxEditDto> IsExists(int id);
    }
}
