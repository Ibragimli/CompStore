using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.RamMhzs
{

    public class RamMhzEditDto
    {
        public int Mhz { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<RamMhzEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Mhz).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
