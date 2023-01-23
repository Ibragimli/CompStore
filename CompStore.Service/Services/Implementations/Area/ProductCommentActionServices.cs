using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ProductCommentActionServices : IProductCommentActionServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommentActionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Comment> AcceptComment(int id)
        {
            var comment = await _getCommnet(id);
            comment.CommentStatus = true;
            await _unitOfWork.CommitAsync();
            return comment;
        }

        public async Task<Comment> RejectComment(int id)
        {
            var comment = await _getCommnet(id);
            comment.CommentStatus = false;
            await _unitOfWork.CommitAsync();
            return comment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            var comment = await _getCommnet(id);
            _unitOfWork.CommentRepository.Remove(comment);
            await _unitOfWork.CommitAsync();
            return comment;
        }

        private async Task<Comment> _getCommnet(int id)
        {
            Comment comment = await _unitOfWork.CommentRepository.GetAsync(x => x.Id == id);
            if (comment == null) throw new ItemNotFoundException("Məhsul tapilmadi!");
            return comment;
        }
    }
}
