using Bee.Data.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Service
{
    public interface IUserService
    {
        bool Delete(int id);
        IEnumerable<User> FindAll();
        User FindOne(int id);
        void Insert(User user);
        bool Update(User user);
    }
}
