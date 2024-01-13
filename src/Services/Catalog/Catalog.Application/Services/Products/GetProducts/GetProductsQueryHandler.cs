using Catalog.Application.Services.Products.DTOs;
using Catalog.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductsQueryHandler> _logger;
        public GetProductsQueryHandler(IProductRepository productRepository, ILogger<GetProductsQueryHandler> logger) 
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<List<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAsync(cancellationToken);
                // use automapper to map to GetProducts
                // return QueryResponse

            }catch (Exception ex)
            {

            }
        }
    }
}
