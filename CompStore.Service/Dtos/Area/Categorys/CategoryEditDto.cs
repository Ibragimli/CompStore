using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Categorys
{
    public class CategoryEditDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreatePostDtoValidator : AbstractValidator<CategoryEditDto>
        {
            public CreatePostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("boş olmamalıdır.");
            }
        }
    }
}
