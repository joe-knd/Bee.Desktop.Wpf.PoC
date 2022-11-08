using Bee.Data.Abstractions;
using Bee.Data.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Service
{
    public interface IService<T> where  T : EntityBase
    {
        bool Delete(int id);
        IEnumerable<T> FindAll();
        T FindOne(int id);
        void Insert(T entity);
        bool Update(T entity);
    }
}
