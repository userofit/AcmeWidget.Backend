using Acme.Models;
using Acme.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestAcme.Fakes
{
    public class SignupRepositoryFake : ISignupRepository
    {
        public IEnumerable<User> GetSignedUpUsers()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "jsmith@acme.com"
            });
            return users;
        }

        public Signup GetSignup(int signupId)
        {
            throw new NotImplementedException();
        }

        public bool SaveSignup(Signup signup)
        {
            throw new NotImplementedException();
        }
    }
}
