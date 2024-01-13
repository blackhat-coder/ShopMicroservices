using Catalog.Domain.Products;
using Catalog.Persistence.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
/*using Microsoft.EntityFrameworkCore;*/

namespace Catalog.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productsCollection; 
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(IOptions<MongoDbConfig> config, ILogger<ProductRepository> logger) 
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(config.Value.Database);

            _productsCollection = mongoDatabase.GetCollection<Product>(typeof(Product).Name);
            _logger = logger;

            CatalogSeeder.SeedData(_productsCollection);
        }

        public async Task<Product?> FindById(ProductId id, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _productsCollection.AsQueryable().Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
                return response;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Product?>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _productsCollection.AsQueryable().ToListAsync();
                return result;
            }catch(Exception ext)
            {
                _logger.LogError(ext.Message);
                return await Task.FromResult(Enumerable.Empty<Product?>());
            }
        }

        public async Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                var filter = Builders<Product>.Filter.Where(predicate);
                var result = await _productsCollection.FindAsync<Product>(filter, cancellationToken: cancellationToken);
                return await result.FirstOrDefaultAsync();
            }
            catch (Exception ext)
            {
                _logger.LogError(ext.Message);
                return null;
            }
        }

        public async Task InsertAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                await _productsCollection.InsertOneAsync(product, cancellationToken: cancellationToken);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task InsertManyAsync(IEnumerable<Product> documents, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                var filter = Builders<Product>.Filter.Where(p => p.Id == product.Id && p.IsDeleted == false);
                var result = await _productsCollection.ReplaceOneAsync(filter, product, cancellationToken: cancellationToken);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
