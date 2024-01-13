using Catalog.Application.Services.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetById
{
    public class GetProductByIdQuery : IRequest<GetProductsQueryResponse>
    {
        public string ProductId { get; set; }
    }
}
