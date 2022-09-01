using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IOperationSystemIndexServices
    {
        Task<IQueryable<OperationSystem>> SearchCheck(string search);
    }
}
