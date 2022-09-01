using CompStore.Service.Dtos.Area.ScreenDiagonals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IScreenDiagonalEditServices
    {
        Task ScreenDiagonalEdit(ScreenDiagonalEditDto ScreenDiagonalEdit);
        Task<ScreenDiagonalEditDto> IsExists(int id);
    }
}
