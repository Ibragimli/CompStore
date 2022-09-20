using CompStore.Service.Dtos.Area.Teyinats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface ITeyinatEditServices
    {
        Task TeyinatEdit(TeyinatEditDto TeyinatEdit);
        Task<TeyinatEditDto> IsExists(int id);
    }
}
