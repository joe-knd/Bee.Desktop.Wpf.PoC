using Bee.Data.Abstractions;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.LiteDb
{
    public class LiteDbRepository : IRepository<ILiteRepository>
    {
        public LiteDbRepository(ILiteRepository repository)
        {
            Repository = repository;
        }

        public LiteDbRepository(IOptions<LiteDbOptions> options)
        {
            var liteDbOptions = options.Value;

            Repository = new LiteRepository(@$"Filename={liteDbOptions.DatabaseLocation}; Connection=Shared;");
        }

        public ILiteRepository Repository { get; }

    }
}
