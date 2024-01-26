using Catalog.Domain.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator() 
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ProductMessages.ProductNameInvalid);
        RuleFor(x =>x.Description).NotEmpty().WithMessage(ProductMessages.ProductDescriptionInvalid);
        RuleFor(x => x.Category).NotEmpty().WithMessage(ProductMessages.ProductCategoryInvalid);
        RuleFor(x => x.stock).NotEmpty().WithMessage(ProductMessages.ProductStockInvalid);
        RuleFor(x => x.Price).NotEmpty().WithMessage(ProductMessages.ProductPriceInvalid);
    }
}
