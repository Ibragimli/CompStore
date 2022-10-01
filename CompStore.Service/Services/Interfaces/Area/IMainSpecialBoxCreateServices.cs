using CompStore.Service.Dtos.Area.MainSpecialBoxs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IMainSpecialBoxCreateServices
    {
        Task CreateMainSpecialBox(MainSpecialBoxCreateDto MainSpecialBoxDto);

    }
}
