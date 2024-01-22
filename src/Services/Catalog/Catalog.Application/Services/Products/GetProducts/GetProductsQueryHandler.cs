using AutoMapper;
using Catalog.Application.DTOs.Products;
using Catalog.Application.Response;
using Catalog.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<GetProductsQueryResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductsQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IProductRepository productRepository, ILogger<GetProductsQueryHandler> logger, IMapper mapper) 
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Result<List<GetProductsQueryResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productQuery = await _productRepository.GetQueryableAsync(x => x.IsDeleted == false, cancellationToken);
                var products = await productQuery.PageResult(request.PageSize, request.PageNum).ToListAsync();
                var response = _mapper.Map<List<GetProductsQueryResponse>>(products);

                return await Result<List<GetProductsQueryResponse>>.SuccessAsync(ProductMessages.GetAllProductsSuccessful, response);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Result<List<GetProductsQueryResponse>>.ExceptionAsync(ex.Message);
            }
        }
    }
}
