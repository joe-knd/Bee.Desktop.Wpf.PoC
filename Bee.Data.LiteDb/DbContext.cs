using Bee.Data.Abstractions;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Bee.Data.LiteDb
{
    public class DbContext : IDbContext<ILiteDatabase>
    {
        public DbContext(ILiteDatabase database)
        {
            Database = database;
        }

        public DbContext(IOptions<LiteDbOptions> options)
        {
            var liteDbOptions = options.Value;
            Database = new LiteDatabase(@$"Filename={liteDbOptions.DatabaseLocation}; Connection=Shared;");
        }

        public ILiteDatabase Database { get; }
    }
}