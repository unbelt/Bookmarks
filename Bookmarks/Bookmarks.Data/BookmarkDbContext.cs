using Microsoft.AspNet.Identity;

namespace Bookmarks.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Data.Migrations;
    using Bookmarks.Exceptions;
    using Bookmarks.Models;

    public class BookmarkDbContext : IdentityDbContext<User>, IBookmarkDbContext
    {
        public const string SqlConnectionString = "Server=.;Database=Bookmarks;Integrated Security=True;";

        public BookmarkDbContext()
            : base(SqlConnectionString, throwIfV1Schema: false)
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<BookmarkDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarkDbContext, Configuration>());
        }

        public static BookmarkDbContext Create()
        {
            return new BookmarkDbContext();
        }

        public DbContext DbContext
        {
            get { return this; }
        }

        public RoleStore<IdentityRole> RoleStore
        {
            get
            {
                return new RoleStore<IdentityRole>(this.DbContext);
            }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return new RoleManager<IdentityRole>(this.RoleStore);
            }
        }

        public UserStore<User> UserStore
        {
            get
            {
                return new UserStore<User>(this.DbContext);
            }
        }

        public UserManager<User> UserManager
        {
            get
            {
                return new UserManager<User>(this.UserStore);
            }
        }

        public virtual IDbSet<Bookmark> Bookmarks { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}