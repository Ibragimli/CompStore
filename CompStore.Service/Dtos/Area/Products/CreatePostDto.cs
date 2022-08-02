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
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(250).WithMessage("Uzunluğu 250 dən böyük ola bilməz!");
            RuleFor(x => x.Product.Price).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ModelId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.DiscountPercent).NotEmpty().WithMessage("boş olmamalıdır."); ;
            RuleFor(x => x.Product.Description).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(500).WithMessage("Uzunluğu 500 dən böyük ola bilməz!");
            RuleFor(x => x.CategoryBrand.BrandId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.CategoryBrand.CategoryId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.GörüntüImkanıId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ColorId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.OperationSystemId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ProcessorCacheId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ProcessorGhzId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ProcessorModelId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.RamDDRId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.RamMhzId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.RamGBId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ScreenDiagonalId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.TeyinatId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.ScreenFrequencyId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.VideokartRamId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.ProductParametr.VideokartId).NotEmpty().WithMessage("boş olmamalıdır.");
        }
    }
}
