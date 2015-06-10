namespace Bookmarks.Data.Repositories
{
    using System.Linq;
    using System.Linq.Expressions;

    using Bookmarks.Data.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        public IQueryable<T> All()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Find(Expression<System.Func<T, bool>> expression)
        {
            throw new System.NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}