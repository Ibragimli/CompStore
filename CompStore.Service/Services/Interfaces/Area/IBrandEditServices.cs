using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IBrandEditServices
    {
        Task BrandEdit(BrandEditDto brandEdit);
        Task<BrandEditDto> IsExists(int id);
    }
}
