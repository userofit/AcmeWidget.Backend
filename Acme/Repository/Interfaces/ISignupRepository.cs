using Acme.Models;
using System.Collections.Generic;

namespace Acme.Repository.Interfaces
{
    public interface ISignupRepository
    {
        Signup GetSignup(int signupId);
        IEnumerable<User> GetSignedUpUsers();
        bool SaveSignup(Signup signup);
    }
}
