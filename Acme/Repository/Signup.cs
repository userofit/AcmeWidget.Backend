using Acme.Infrastructure;
using Acme.Models;
using Acme.Repository.Common;
using Acme.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Repository
{
    public class SignupRepository : AcmeRepositoryDisposal, ISignupRepository
    {
        private AcmeDbContext _dbCtx;

        public SignupRepository(AcmeDbContext acmeDbContext)
        {
            _dbCtx = acmeDbContext;
        }

        public Signup GetSignup(int signupId)
        {
            return _dbCtx.AcmeDbConnection.Query<Signup>($"SELECT * FROM Signups WHERE SignupId = { signupId }").FirstOrDefault();
        }

        public IEnumerable<User> GetSignedUpUsers()
        {
            return _dbCtx.AcmeDbConnection.Query<User>(@"SELECT u.* FROM Signups s INNER JOIN Users u ON s.UserId = u.UserId");
        }

        public bool SaveSignup(Signup signup)
        {
            var existingSignup = GetSignup(signup.SignupId);
            if (existingSignup == null)
            {
                var newSignupId = CreateSignup(signup);
                return newSignupId > 0;
            }

            #region Here we may user AutoMapper
            existingSignup.Activity = signup.Activity;
            existingSignup.Comments = signup.Comments;
            existingSignup.User = signup.User;
            #endregion

            var retValue = _dbCtx.SaveChanges();
            if (retValue == 0) _dbCtx.Entry(signup).State = EntityState.Modified;
            return retValue == 0;
        }

        public override void Dispose()
        {
            Dispose(_dbCtx);
        }

        private int CreateSignup(Signup signup)
        {
            var newSignup = _dbCtx.Attach(signup);
            _dbCtx.SaveChanges();
            return newSignup.Entity.SignupId;
        }
    }
}
