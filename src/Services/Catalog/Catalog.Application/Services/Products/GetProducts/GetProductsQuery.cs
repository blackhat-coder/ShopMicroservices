using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Products.GetProducts
{
    public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
    {
        public int PageSize = 10;
        public int Number = 1;
    }
}
