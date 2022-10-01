using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.MainSpecialBoxs
{
    
    public class MainSpecialBoxEditDto
    {
        public MainSpecialBox MainSpecialBox { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<MainSpecialBoxEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.MainSpecialBox.Title).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(50);
            }
        }
    }
}
