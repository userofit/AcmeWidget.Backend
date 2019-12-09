using Acme.BLL.Interfaces;
using Acme.Models;
using Acme.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BLL
{
    public class SignupManager : ISignupManager
    {
        private IUserRepository _userRepository;
        private ISignupRepository _signupRepository;
        public SignupManager(ISignupRepository signupRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _signupRepository = signupRepository;
        }

        public bool UserHasSignedup(int userId)
        {
            return _signupRepository.GetSignedUpUsers().FirstOrDefault(x => x.UserId == userId) != null;
        }

        public IEnumerable<User> GetSignedUpUsers()
        {
            return _signupRepository.GetSignedUpUsers();
        }

        public void SaveUserSignup(Signup signup, int userId)
        {
            signup.User = _userRepository.GetUser(userId);
            _signupRepository.SaveSignup(signup);
        }
    }
}
