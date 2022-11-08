using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Abstractions
{
    public interface IDbContext<T> where T : class
    {
        T Database { get; }
    }
}
