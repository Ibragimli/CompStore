using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface ICommentAddServices
    {
        Task<Comment> CreateComment(Comment comment/*, IList<Product> sliderProduct*/);

    }
}
