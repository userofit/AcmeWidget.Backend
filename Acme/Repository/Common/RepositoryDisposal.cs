using Acme.Infrastructure;
using System;

namespace Acme.Repository.Common
{
    public class AcmeRepositoryDisposal : IDisposable
    {
        private bool disposed = false;

        private void Dispose(bool disposing, AcmeDbContext dbCtx)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbCtx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose(AcmeDbContext dbCtx)
        {
            Dispose(true, dbCtx);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
