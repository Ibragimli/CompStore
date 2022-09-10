using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.CategoryBrandIds
{
    public class CategoryBrandIdEditDto
    {
        public CategoryBrandId CategoryBrandId { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Category> Categories { get; set; }
        public class CreatePostDtoValidator : AbstractValidator<CategoryBrandIdEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.CategoryBrandId.BrandId).NotEmpty().WithMessage("boş olmamalıdır.");
                RuleFor(x => x.CategoryBrandId.CategoryId).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
