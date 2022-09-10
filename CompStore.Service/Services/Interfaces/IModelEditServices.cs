using CompStore.Service.Dtos.Area.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IModelEditServices
    {
        Task ModelEdit(ModelEditDto ModelEdit);
        Task<ModelEditDto> IsExists(int id);
    }
}
