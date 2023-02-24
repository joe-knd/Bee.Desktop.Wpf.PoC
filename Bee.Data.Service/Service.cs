using Bee.Data.Abstractions;
using Bee.Data.Service.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Service
{
    public class Service<T> : IService<T> where T : EntityBase
    {
        private readonly ILiteRepository _repository;

        public Service(IRepository<ILiteRepository> repository)
        {
            _repository = repository.Repository;
        }

        public bool Delete(int id)
        {
            var delete = _repository.Delete<T>(id);
            return delete;
        }

        public IEnumerable<T> FindAll()
        {
            var query = _repository.Query<T>();
            return query.ToEnumerable();
        }

        public T FindOne(int id)
        {
            var query = _repository.Query<T>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return query;
        }

        public void Insert(T entity)
        {
            _repository.Insert<T>(entity);
        }

        public bool Update(T entity)
        {
            var update = _repository.Update<T>(entity);
            return update;
        }
    }
}
