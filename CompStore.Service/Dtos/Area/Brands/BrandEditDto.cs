using CompStore.Core.Entites;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Brands
{
    public class BrandEditDto
    {
        public Brand Brand { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<BrandEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Brand.Name).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(50);
            }
        }
    }
}
