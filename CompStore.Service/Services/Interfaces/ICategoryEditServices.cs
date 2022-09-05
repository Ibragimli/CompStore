using CompStore.Service.Dtos.Area.Categorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ICategoryEditServices
    {
        Task CategoryEdit(CategoryEditDto CategoryEdit);
        Task<CategoryEditDto> IsExists(int id);
    }
}
