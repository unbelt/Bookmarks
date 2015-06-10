namespace Bookmarks.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}