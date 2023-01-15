using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{
    public class CommentAddServices : ICommentAddServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentAddServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {

            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == comment.ProductId);
            if (product == null) throw new ItemNotFoundException("Məhsul tapılmadı!");
            if (comment.Text == null)
                throw new SizeFormatException("Rəyinizin boş ola bilməz");

            AppUser user = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name) : null;
            if (user == null)
            {
                if (comment.Fullname == null)
                    throw new SizeFormatException("Ad Soyad boş ola bilməz");
                if (comment.Email == null)
                    throw new SizeFormatException("Email boş ola bilməz");
                if (comment.Email.Length > 50)
                    throw new SizeFormatException("Emailinizin uzunluğu sözdən 50-dən çox ola bilməz");
                if (comment.Fullname.Length > 50)
                    throw new SizeFormatException("Adınız və soyadınızın uzunluğu sözdən 50-dən çox ola bilməz");
            }

            if (comment.Text.Length > 1001)
                throw new SizeFormatException("Rəyinizin uzunluğu 1000 sözdən çox ola bilməz");
            
            if (comment.Rate == 0)
                comment.Rate = 1;

            if (user != null)
            {
                comment.Email = user.Email;
                comment.Fullname = user.FullName;
                comment.AppUserId = user.Id;
                comment.CommentStatus = false;
                comment.Time = DateTime.UtcNow.AddHours(4);
                await _unitOfWork.CommentRepository.InsertAsync(comment);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                comment.CommentStatus = false;
                comment.Time = DateTime.UtcNow.AddHours(4);
                await _unitOfWork.CommentRepository.InsertAsync(comment);
                await _unitOfWork.CommitAsync();
            }
            return comment;
        }
    }
}
