using CompStore.Service.Dtos.Area.HDDHecms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IHDDHecmEditServices
    {
        Task HDDHecmEdit(HDDHecmEditDto HDDHecmEdit);
        Task<HDDHecmEditDto> IsExists(int id);
    }
}
