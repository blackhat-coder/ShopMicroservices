using Catalog.Application.Response;
using Catalog.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository _productRepository, ILogger<DeleteProductCommandHandler> _logger) 
        : IRequestHandler<DeleteProductCommand, Result>
    {
        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pid = ObjectId.Parse(request.ProductId);
                var product = await _productRepository.GetAsync(x => x.Id == new ProductId(pid) && !x.IsDeleted);
                

                if (product == null)
                {
                    return await Result.FailAsync(ProductMessages.NotFound, HttpStatusCode.NotFound);
                }

                product.IsDeleted = true;
                await _productRepository.UpdateAsync(product);

                _logger.LogInformation(ProductMessages.ProductDeleted);
                return await Result.SuccessAsync(ProductMessages.ProductDeleted);

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Result.ExceptionAsync(ex.Message);
            }
        }
    }
}
