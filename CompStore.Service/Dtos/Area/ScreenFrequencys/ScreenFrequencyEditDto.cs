using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.ScreenFrequencys
{
    public class ScreenFrequencyEditDto
    {
        public string Frequency { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ScreenFrequencyEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Frequency).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
