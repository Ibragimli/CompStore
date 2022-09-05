using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.HDDHecms
{

    public class HDDHecmEditDto
    {
        public string Cache { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<HDDHecmEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Cache).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
