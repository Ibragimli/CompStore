using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{
    public class ContactUsPostDto
    {
        public ContactUs ContactUs { get; set; }
    }
    public class ContactUsPostDtoValidator : AbstractValidator<ContactUsPostDto>
    {
        public ContactUsPostDtoValidator()
        {
            RuleFor(x => x.ContactUs.Text).NotEmpty().WithMessage("Rəy hissəsi boş olmamalıdır.").MaximumLength(1000).WithMessage("Uzunluğu 1000 dən böyük ola bilməz!");
            RuleFor(x => x.ContactUs.Subject).NotEmpty().WithMessage("Mövzu hissəsi boş olmamalıdır.").MaximumLength(80).WithMessage("Uzunluğu 80 dən böyük ola bilməz!");
            RuleFor(x => x.ContactUs.Email).NotEmpty().WithMessage("Email hissəsi boş olmamalıdır.").MaximumLength(50).WithMessage("Uzunluğu 50 dən böyük ola bilməz!");
            RuleFor(x => x.ContactUs.FullName).NotEmpty().WithMessage("Ad Soyad hissəsi boş olmamalıdır.").MaximumLength(50).WithMessage("Uzunluğu 50 dən böyük ola bilməz!");
        }
    }
}
