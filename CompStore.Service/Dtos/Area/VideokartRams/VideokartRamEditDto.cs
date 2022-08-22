using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.VideokartRams
{
    public class VideokartRamEditDto
    {
        public int Ram { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<VideokartRam>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Ram).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
