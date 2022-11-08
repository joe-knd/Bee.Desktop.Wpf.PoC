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
    public class UserService : IUserService
    {
        private readonly ILiteRepository _repository;

        public UserService(IRepository<ILiteRepository> repository) 
        { 
            _repository = repository.Repository;
        }

        public bool Delete(int id)
        {
            var delete = _repository.Delete<User>(id);
            return delete;
        }

        public IEnumerable<User> FindAll()
        {
            var query = _repository.Query<User>();
            return query.ToEnumerable();
        }

        public User FindOne(int id)
        {
            var query = _repository.Query<User>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return query;
        }

        public void Insert(User user)
        {
            _repository.Insert<User>(user);
        }

        public bool Update(User user)
        {
            var update = _repository.Update<User>(user);
            return update;
        }
    }
}
