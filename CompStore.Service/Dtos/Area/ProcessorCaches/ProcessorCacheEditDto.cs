using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.ProcessorCaches
{
    public class ProcessorCacheEditDto
    {
        public double Cache { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<ProcessorCache>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Cache).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
