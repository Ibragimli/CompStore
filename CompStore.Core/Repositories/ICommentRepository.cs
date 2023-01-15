using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompStore.Core.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> asQueryableComment();
    }
}
