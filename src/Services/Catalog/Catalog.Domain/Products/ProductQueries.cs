using Catalog.Domain.Products;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Products;

public static class ProductQueries
{
    public static IMongoQueryable<Product> PageResult(this IMongoQueryable<Product> query, int pageSize = 10, int pageNum = 0)
    {
        query = query.Skip(pageNum * pageSize).Take(pageSize);
        return query;
    }
}
