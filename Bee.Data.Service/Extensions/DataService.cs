using Bee.Data.Abstractions;
using Bee.Data.LiteDb;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Service.Extensions
{
    public static class DataService
    {
        public static void AddDataService<T>(this IServiceCollection services) where T : EntityBase
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            
            services.AddSingleton<IService<T>, Service<T>>();
        }

        public static void AddRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IRepository<ILiteRepository>, LiteDbRepository>();
        }
    }
}
