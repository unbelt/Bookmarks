namespace Bookmarks.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Bookmarks.Models;

    public interface IBookmarkDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Bookmark> Bookmarks { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Vote> Votes { get; }

        DbContext DbContext { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entry) where TEntity : class;

        RoleStore<IdentityRole> RoleStore { get; }

        UserStore<User> UserStore { get; }

        int SaveChanges();

        void Dispose();
    }
}