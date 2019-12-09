using Acme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        User GetUser(string userEmail);
        void DeleteUser(int userId);
        void DeleteUser(string userEmail);
        bool SaveUser(User user);
    }
}
