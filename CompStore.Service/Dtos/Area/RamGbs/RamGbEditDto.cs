using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.RamGbs
{
    public class RamGbEditDto
    {
        public class RamGBEditDto
        {
            public int GB { get; set; }
            public int Id { get; set; }

            public class CreatePostDtoValidator : AbstractValidator<RamGBEditDto>
            {
                public CreatePostDtoValidator()
                {
                    RuleFor(x => x.GB).NotEmpty().WithMessage("boş olmamalıdır.");
                }
            }
        }
    }
}
