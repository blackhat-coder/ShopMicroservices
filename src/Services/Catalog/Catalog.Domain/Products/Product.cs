using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Common;

namespace Catalog.Domain.Products;

public class Product : BaseEntity<ProductId>
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public Money Price {  get; set; }   
}