using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.MainSliders
{
    public class MainSliderEditDto
    {
        public MainSlider MainSlider { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<MainSliderEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.MainSlider.Description).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(200);
                RuleFor(x => x.MainSlider.Title).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(50);
            }
        }
    }
}
