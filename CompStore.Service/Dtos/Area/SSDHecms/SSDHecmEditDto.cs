using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.SSDHecms
{
    public class SSDHecmEditDto
    {
        public string Cache { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<SSDHecmEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Cache).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
