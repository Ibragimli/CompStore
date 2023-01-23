using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IProductCommentActionServices
    {
        public Task<Comment> AcceptComment(int id);
        public Task<Comment> RejectComment(int id);
        public Task<Comment> DeleteComment(int id);
    }
}
