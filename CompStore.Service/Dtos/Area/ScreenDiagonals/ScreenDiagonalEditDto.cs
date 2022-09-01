using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.ScreenDiagonals
{
    public class ScreenDiagonalEditDto
    {
        public string Diagonal { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ScreenDiagonalEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Diagonal).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
