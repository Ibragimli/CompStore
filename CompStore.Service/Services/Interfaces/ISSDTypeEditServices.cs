using CompStore.Service.Dtos.Area.SSDTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ISSDTypeEditServices
    {
        Task SSDTypeEdit(SSDTypeEditDto SSDTypeEdit);
        Task<SSDTypeEditDto> IsExists(int id);
    }
}
