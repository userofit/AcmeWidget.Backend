using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Acme.Repository
{
    /// <summary>
    /// This generic repository has not been applied yet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IQueryable<T> where T : class
    {
        private readonly IQueryable<T> query;

        protected GenericRepository(IQueryable<T> query)
        {
            this.query = query;
        }

        public Type ElementType
        {
            get { return this.query.ElementType; }
        }

        public Expression Expression
        {
            get { return this.query.Expression; }
        }

        public virtual IQueryProvider Provider
        {
            get { return this.query.Provider; }
        }

        public abstract void InsertOnSubmit(T entity);

        public abstract void DeleteOnSubmit(T entity);

        public void InsertAllOnSubmit(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.InsertOnSubmit(entity);
            }
        }

        public void DeleteAllOnSubmit(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.DeleteOnSubmit(entity);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.query.GetEnumerator();
        }
    }
}
