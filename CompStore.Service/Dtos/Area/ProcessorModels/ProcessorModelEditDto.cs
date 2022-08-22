using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.ProcessorModels
{
    public class ProcessorModelEditDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ProcessorModel>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
