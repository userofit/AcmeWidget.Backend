using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Infrastructure
{
    public class AcmeDbContext : DbContext
    {
        public AcmeDbContext(DbContextOptions options) : base(options)
        {
            var sqlServerOptionsExtension = options.FindExtension<SqlServerOptionsExtension>();
            if (sqlServerOptionsExtension != null)
            {
                AcmeDbConnection = sqlServerOptionsExtension.Connection as SqlConnection;
                if (AcmeDbConnection == null)
                {
                    AcmeDbConnection = new SqlConnection(sqlServerOptionsExtension.ConnectionString);
                }
            }
        }

        public SqlConnection AcmeDbConnection { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Signup> Signups { get; set; }
    }
}
