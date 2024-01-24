using Catalog.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public int stock { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
