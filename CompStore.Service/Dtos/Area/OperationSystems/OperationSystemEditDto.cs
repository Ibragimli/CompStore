using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.OperationSystems
{
   public class OperationSystemEditDto
    {
        public string System { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<OperationSystemEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.System).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
