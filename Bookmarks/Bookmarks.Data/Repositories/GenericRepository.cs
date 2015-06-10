namespace Bookmarks.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Bookmarks.Data.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        public GenericRepository(IBookmarkDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IBookmarkDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; } 

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public IQueryable<T> Find(Expression<System.Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);

            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);

            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entry = this.DbSet.Find(id);
            this.Delete(entry);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private T ChangeState(T entity, EntityState state)
        {
            this.Attach(entity);

            var entry = this.Context.Entry(entity);
            entry.State = state;

            return entity;
        }

        private void Attach(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
        }
    }
}