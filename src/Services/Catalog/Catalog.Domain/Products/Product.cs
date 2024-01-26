using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Common;
using MongoDB.Bson;

namespace Catalog.Domain.Products;

public class Product : BaseEntity<ProductId>
{
    public string Name { get; private set; }
    public ProductCategory Category { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public int AvailableStock { get; private set; }
    public Money Price {  get; private set; }
    
    public static Product CreateProduct(string name, ProductCategory category, string summary, string description, string imageFile, int stock, Money price)
    {
        // perform domain validations
        var product = new Product
        {
            Id = new ProductId(ObjectId.GenerateNewId()),
            Name = Name,
            Category = category,
            Summary = summary,
            Description = description,
            ImageFile = imageFile,
            AvailableStock = stock,
            Price = price,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return product;
    }
}
