using Catalog.Application.Services.Products.CreateProduct;
using Catalog.Application.Services.Products.GetById;
using Catalog.Application.Services.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController(IMediator _mediator) : BaseController
    {

        [HttpGet("get-all-products")]
        public async Task<ActionResult> GetProducts(GetProductsQuery request)
        {
            var products = await _mediator.Send(request);
            return ApiResponse(products);
        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult> GetProductById(GetProductByIdQuery request)
        {
            var product = await _mediator.Send(request);
            return ApiResponse(product);
        }

        [HttpPost("create-product")]
        public async Task<ActionResult> CreateProduct(CreateProductCommand request)
        {
            var product = await _mediator.Send(request);
            return ApiResponse(product);
        }
    }
}
