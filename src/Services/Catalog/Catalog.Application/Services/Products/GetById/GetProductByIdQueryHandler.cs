using Catalog.Application.Services.Products.DTOs;
using Catalog.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;
        public GetProductByIdQueryHandler(IProductRepository productRepository, ILogger<GetProductByIdQueryHandler> logger) 
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public Task<GetProductsQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
