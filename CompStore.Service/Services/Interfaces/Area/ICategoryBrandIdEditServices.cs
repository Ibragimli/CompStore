using CompStore.Service.Dtos.Area.CategoryBrandIds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface ICategoryBrandIdEditServices
    {
        Task CategoryBrandIdEdit(CategoryBrandIdEditDto CategoryBrandIdEdit);
        Task<CategoryBrandIdEditDto> IsExists(int id);
    }
}
