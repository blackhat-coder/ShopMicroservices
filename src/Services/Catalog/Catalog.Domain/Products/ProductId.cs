using MongoDB.Bson;

namespace Catalog.Domain.Products;

public record ProductId(ObjectId Value);