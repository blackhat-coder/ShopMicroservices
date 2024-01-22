using AutoMapper;
using Catalog.Application.DTOs.Products;
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

namespace Catalog.Application.Services.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<GetProductsQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository, ILogger<GetProductByIdQueryHandler> logger, IMapper mapper) 
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Result<GetProductsQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pId = ObjectId.Parse(request.ProductId);
                var product = await _productRepository.GetAsync(p => p.Id == new ProductId(pId), cancellationToken);

                if (product == null) {
                    return await Result<GetProductsQueryResponse>.FailAsync(
                        ProductMessages.NotFound,
                        new ErrorDetails(HttpStatusCode.NotFound, new List<string> { ProductMessages.NotFound})
                        );
                }

                var response = _mapper.Map<GetProductsQueryResponse>(product);

                _logger.LogInformation("Retrieved Product");
                return await Result<GetProductsQueryResponse>.SuccessAsync(ProductMessages.GetProductSuccess, response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Result<GetProductsQueryResponse>.ExceptionAsync(ex.Message);
            }
        }
    }
}
