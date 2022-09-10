using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Models
{
    public class ModelEditDto
    {

        public Model Model { get; set; }
        public int BrandId { get; set; }
        public int CategoryBrandIdId { get; set; }

        public ICollection<Brand> Brands { get; set; }
        public ICollection<CategoryBrandId> CategoryBrandIds { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ModelEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Model.Id).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
