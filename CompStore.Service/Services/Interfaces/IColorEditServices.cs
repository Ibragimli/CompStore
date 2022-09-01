using CompStore.Service.Dtos.Area.Colors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IColorEditServices
    {
        Task ColorEdit(ColorEditDto ColorEdit);
        Task<ColorEditDto> IsExists(int id);
    }
}
