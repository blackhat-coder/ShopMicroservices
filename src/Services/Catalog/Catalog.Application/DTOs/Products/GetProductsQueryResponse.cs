using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs.Products;

public class GetProductsQueryResponse
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public string Currency { get; set; }
    public decimal Price { get; set; }
}
