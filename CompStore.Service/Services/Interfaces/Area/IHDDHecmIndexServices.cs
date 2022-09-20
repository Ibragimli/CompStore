using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IHDDHecmIndexServices
    {
        Task<IQueryable<HDDHecm>> SearchCheck(string search);
    }
}
