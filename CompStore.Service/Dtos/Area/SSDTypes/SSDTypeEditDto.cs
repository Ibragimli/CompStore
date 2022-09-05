using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.SSDTypes
{
    public class SSDTypeEditDto
    {
        public string Type { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<SSDTypeEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Type).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
