using CompStore.Service.Dtos.Area.SSDHecms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ISSDHecmEditServices
    {
        Task SSDHecmEdit(SSDHecmEditDto SSDHecmEdit);
        Task<SSDHecmEditDto> IsExists(int id);
    }
}
