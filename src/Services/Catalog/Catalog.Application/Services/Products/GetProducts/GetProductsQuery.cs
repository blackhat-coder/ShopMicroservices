using Catalog.Application.DTOs.Products;
using Catalog.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetProducts
{
    public class GetProductsQuery : IRequest<Result<List<GetProductsQueryResponse>>>
    {
        public int PageSize = 10;
        public int PageNum = 0;
    }
}
