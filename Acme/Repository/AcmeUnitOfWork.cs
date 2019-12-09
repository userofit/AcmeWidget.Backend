using Acme.Infrastructure;
using Acme.Repository.Interfaces;
using System;

namespace Acme.Repository
{
    public class AcmeUnitOfWork : IAcmeUnitOfWork, IDisposable
    {
        private AcmeDbContext _dbContext;
        private IUserRepository _userRepo;
        private ISignupRepository _signupRepo;

        public AcmeUnitOfWork(AcmeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUserRepository Users
        {
            get
            {

                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_dbContext);
                }
                return _userRepo;
            }
        }

        public ISignupRepository Signups
        {
            get
            {

                if (_signupRepo == null)
                {
                    _signupRepo = new SignupRepository(_dbContext);
                }
                return _signupRepo;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
