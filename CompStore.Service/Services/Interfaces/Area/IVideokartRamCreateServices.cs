using CompStore.Service.Dtos.Area.VideokartRams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IVideokartRamCreateServices
    {
        Task CreateRam(VideokartRamCreateDto VideokartRamDto);

    }
}
