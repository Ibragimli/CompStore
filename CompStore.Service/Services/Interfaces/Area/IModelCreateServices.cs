using CompStore.Service.Dtos.Area.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IModelCreateServices
    {
        Task ModelCreate(ModelCreateDto brandDto);

    }
}
