using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.ProcessorGhzs
{
    public class ProcessorGhzEditDto
    {
        public int Ghz { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ProcessorGhz>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Ghz).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }

}
