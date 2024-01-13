using Catalog.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence
{
    public static class CatalogPersistenceServiceRegistration
    {
        public static IServiceCollection AddCatalogPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbConfig>("");
            return services;
        }
    }
}
