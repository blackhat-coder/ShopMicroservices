using Catalog.Application.DTOs.Products;
using Catalog.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetById
{
    public class GetProductByIdQuery : IRequest<Result<GetProductsQueryResponse>>
    {
        public string ProductId { get; set; }
    }
}
