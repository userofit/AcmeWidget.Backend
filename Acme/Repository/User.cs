using Acme.Infrastructure;
using Acme.Models;
using Acme.Repository.Common;
using Acme.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Acme.Repository
{
    public class UserRepository : AcmeRepositoryDisposal, IUserRepository
    {
        private AcmeDbContext _dbCtx;

        public UserRepository(AcmeDbContext acmeDbContext)
        {
            _dbCtx = acmeDbContext;
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userEmail)
        {
            throw new NotImplementedException();
        }
        public User GetUser(int userId)
        {
            return _dbCtx.AcmeDbConnection.Query<User>($"SELECT * FROM Users WHERE Id = { userId }").FirstOrDefault();
        }

        public User GetUser(string userEmail)
        {
            return _dbCtx.AcmeDbConnection.Query<User>($"SELECT * FROM Users WHERE Email = '{ userEmail }'").FirstOrDefault();
        }

        public bool SaveUser(User user)
        {
            var existingUser = GetUser(user.Email);
            if (existingUser == null)
            {
                var newUserId = CreateUser(user);
                return newUserId > 0;
            }

            #region Here we may user AutoMapper
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email; 
            #endregion

            var retValue = _dbCtx.SaveChanges();
            if (retValue == 0) _dbCtx.Entry(user).State = EntityState.Modified;
            return retValue == 0;
        }

        public override void Dispose()
        {
            Dispose(_dbCtx);
        }

        private int CreateUser(User user)
        {
            var newUser = _dbCtx.Add(user);
            _dbCtx.SaveChanges();
            return newUser.Entity.UserId;
        }
    }
}
