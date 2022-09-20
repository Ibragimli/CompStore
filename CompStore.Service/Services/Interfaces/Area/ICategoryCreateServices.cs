using CompStore.Service.Dtos.Area.Categorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface ICategoryCreateServices
    {
        Task CreateGB(CategoryCreateDto brandDto);

    }
}
