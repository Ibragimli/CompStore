using CompStore.Service.Dtos.Area.Teyinats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface ITeyinatCreateServices
    {
        Task CreateTeyinat(TeyinatCreateDto TeyinatCreateDto);

    }
}
