using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Products
{
    public class CreatePostDto
    {
        public Product Product { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public Model Model { get; set; }
        public CategoryBrandId CategoryBrand { get; set; }
    }
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
        }
    }
}
