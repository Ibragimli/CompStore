using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.GörüntüImkanıs
{
    public class GörüntüImkanıEditDto
    {
        public string Capability { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<GörüntüImkanıEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Capability).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
