using CompStore.Core.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Products
{
    public class EditPostDto
    {
        public Product Product { get; set; }
    }
    public class EditPostDtoValidator : AbstractValidator<EditPostDto>
    {
        public EditPostDtoValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty();
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(250).WithMessage("Uzunluğu 250 dən böyük ola bilməz!");
            RuleFor(x => x.Product.Price).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ModelId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.DiscountPercent).NotEmpty().WithMessage("boş olmamalıdır."); ;
            RuleFor(x => x.Product.Description).NotEmpty().WithMessage("boş olmamalıdır.").MaximumLength(500).WithMessage("Uzunluğu 500 dən böyük ola bilməz!");
            RuleFor(x => x.Product.CategoryBrandId.BrandId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.CategoryBrandId.CategoryId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.GörüntüImkanıId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ColorId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.OperationSystemId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ProcessorCacheId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ProcessorGhzId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ProcessorModelId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.RamDDRId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.RamMhzId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.RamGBId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ScreenDiagonalId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.TeyinatId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.ScreenFrequencyId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.VideokartRamId).NotEmpty().WithMessage("boş olmamalıdır.");
            RuleFor(x => x.Product.ProductParametr.VideokartId).NotEmpty().WithMessage("boş olmamalıdır.");
        }
    }
}
