using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ProductCommentIndexServices : IProductCommentIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommentIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Comment>> SearchCheck(string search, int productId)
        {
            var CommentLast = _unitOfWork.CommentRepository.asQueryableComment();

            var Comment = _unitOfWork.CommentRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool textSearch = await Comment.IsExistAsync(x => x.Text.ToLower() == search);
                if (textSearch)
                    CommentLast = CommentLast.Where(x => x.Text.ToLower().Contains(search));
            }
            return CommentLast.Where(x=>x.ProductId == productId);
        }
    }
}
