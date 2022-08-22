using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Videokarts
{
    public class VideokartEditDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<Videokart>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
