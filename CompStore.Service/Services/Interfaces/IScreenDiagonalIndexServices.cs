using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IScreenDiagonalIndexServices
    {
        Task<IQueryable<ScreenDiagonal>> SearchCheck(string search);
    }
}
