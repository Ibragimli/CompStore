using CompStore.Service.Dtos.Area.Colors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IColorCreateServices
    {
        Task CreateColor(ColorCreateDto brandDto);
    }
}
