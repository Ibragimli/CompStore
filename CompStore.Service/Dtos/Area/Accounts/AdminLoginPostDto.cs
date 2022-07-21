using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos
{
    public class AdminLoginPostDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AdminLoginPostDtoValidator : AbstractValidator<AdminLoginPostDto>
    {
        public AdminLoginPostDtoValidator()
        {
            RuleFor(x => x.Username).MaximumLength(50).NotNull();
        }
    }
}
