using Acme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BLL.Interfaces
{
    public interface ISignupManager
    {
        void SaveUserSignup(Signup signup, int userId);
        IEnumerable<User> GetSignedUpUsers();
        bool UserHasSignedup(int userId);
    }
}
