using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();

    }
}
