using CompStore.Service.Dtos.Area.HDDHecms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IHDDHecmCreateServices
    {
        Task CreateGB(HDDHecmCreateDto brandDto);

    }
}
