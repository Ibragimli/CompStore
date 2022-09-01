using CompStore.Service.Dtos.Area.ScreenDiagonals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IScreenDiagonalCreateServices
    {
        Task CreateGB(ScreenDiagonalCreateDto brandDto);

    }
}
