using Catalog.Application.Response;
using Catalog.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<Result<CreateProductResponse>>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public int stock { get; set; } = 1;
        public decimal Price { get; set; } = 1;
        public string Currency { get; set; } = "USD";
    }
}
