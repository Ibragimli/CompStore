using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Teyinats
{
    public class TeyinatEditDto
    {
        public string Type { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<TeyinatEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Type).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
