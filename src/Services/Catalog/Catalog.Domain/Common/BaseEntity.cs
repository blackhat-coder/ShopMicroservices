using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeletedAt { get; set; }
    }
}
