using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Products
{
    public static class ProductMessages
    {
        public const string GetAllProductsSuccessful = "Successfully Retrieved all products";
        public const string NotFound = "Couldn't Retrieve product";
        public const string GetProductSuccess = "Successfully Retrieved Product";


        public const string ValidationFailed = "Validation Failed";
        public const string ProductCreated = "ProductCreatedSuccessfully";

        public const string ProductNameInvalid = "Product name cannot be emtpy";
        public const string ProductDescriptionInvalid = "Product description cannot be empty";
        public const string ProductCategoryInvalid = "Product Category cannot be empty";
        public const string ProductStockInvalid = "Product Stock cannot be 0";
        public const string ProductPriceInvalid = "Product price cannot empty";
        public const string ProductDeleted = "Product Deleted";
    }
}
