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

        IDbSet<Vote> Votes { get; }

        DbContext DbContext { get; }

        RoleStore<IdentityRole> RoleStore { get; }

        UserStore<User> UserStore { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entry) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}