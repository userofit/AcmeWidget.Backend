using Acme.Repository.Interfaces;
using System;
using XUnitTestAcme.Fakes;

namespace AcmeXUnitTest.Fakes
{
    public class AcmeUnitOfWorkFake : IAcmeUnitOfWork
    {      
        private ISignupRepository _signupRepo;
        public AcmeUnitOfWorkFake()
        {

        }
        
        public ISignupRepository Signups
        {
            get
            {
                if (_signupRepo == null)
                {
                    _signupRepo = new SignupRepositoryFake();
                }
                return _signupRepo;
            }
        }
    }
}
