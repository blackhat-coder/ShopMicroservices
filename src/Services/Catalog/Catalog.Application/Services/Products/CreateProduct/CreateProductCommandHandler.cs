using Catalog.Application.Response;
using Catalog.Application.Utils;
using Catalog.Domain.Common;
using Catalog.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.CreateProduct;

public class CreateProductCommandHandler(IProductRepository _productRepository, ILogger<CreateProductCommandHandler> _logger)
    : IRequestHandler<CreateProductCommand, Result<CreateProductResponse>>
{
    public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Creating Products");
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            var category = Enum.Parse<ProductCategory>(request.Category);
            if (validationResult != null)
            {
                return await Result<CreateProductResponse>.FailAsync(ProductMessages.ValidationFailed,
                    new ErrorDetails(HttpStatusCode.BadRequest, validationResult.TransformToList()));
            }

            var product = Product.CreateProduct(request.Name, 
                category, 
                request.Summary, 
                request.Description, 
                request.ImageFile, 
                request.stock, 
                new Money(request.Currency, request.Price));

            await _productRepository.InsertAsync(product);
            var response = new CreateProductResponse()
            {
                ProductId = product.Id.Value.ToString()
            };

            return await Result<CreateProductResponse>.SuccessAsync(ProductMessages.ProductCreated, response);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return await Result<CreateProductResponse>.ExceptionAsync(ex.Message);
        }
    }
}
