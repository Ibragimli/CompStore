using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Brands
{
    public class BrandEditDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<BrandEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(50);
            }
        }
    }
}
