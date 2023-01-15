using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{
    public class ProductDetailDto
    {
        public Product Products { get; set; }
        public ProductCommentPostDto ProductCommentPostDto { get; set; }
        public Comment Comments { get; set; }
        public List<Comment> UserComments { get; set; }
        public ICollection<Product> SliderProducts { get; set; }
    }
    public class ProductCommentPostDto
    {
        public int ProductId { get; set; }
        public Comment Comment { get; set; }
    }
    public class ProductCommentPostDtoValidator : AbstractValidator<ProductCommentPostDto>
    {
        public ProductCommentPostDtoValidator()
        {
           RuleFor(x => x.Comment.Rate).NotEmpty().WithMessage("Məhsul tapılmadı!").GreaterThan(0).WithMessage("Məhsulu qiymətləndirin!");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Məhsul tapılmadı!");
            RuleFor(x => x.Comment.Text).NotEmpty().WithMessage("Rəy hissəsi boş olmamalıdır.").MaximumLength(1000).WithMessage("Uzunluğu 1000 dən böyük ola bilməz!");
            RuleFor(x => x.Comment.Email).NotEmpty().WithMessage("Email hissəsi boş olmamalıdır.").MaximumLength(50).WithMessage("Uzunluğu 50 dən böyük ola bilməz!");
            RuleFor(x => x.Comment.Fullname).NotEmpty().WithMessage("Ad Soyad hissəsi boş olmamalıdır.").MaximumLength(50).WithMessage("Uzunluğu 50 dən böyük ola bilməz!");
        }
    }
}
