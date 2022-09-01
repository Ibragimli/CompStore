using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Colors
{
    public class ColorEditDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ColorEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
