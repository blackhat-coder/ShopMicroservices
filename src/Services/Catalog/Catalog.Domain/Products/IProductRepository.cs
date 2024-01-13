using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Products
{
    public interface IProductRepository
    {
        Task InsertAsync(Product product, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<Product> documents, CancellationToken cancellationToken = default);

        Task UpdateAsync(Product product , CancellationToken cancellationToken = default);

        Task<Product?> FindById(ProductId id, CancellationToken cancellationToken = default);

        Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product?>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
