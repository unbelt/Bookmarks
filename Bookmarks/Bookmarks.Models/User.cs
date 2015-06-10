namespace Bookmarks.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Bookmark> bookmarks;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        public virtual ICollection<Bookmark> Bookmarks
        {
            get
            {
                return this.bookmarks;
            }

            set
            {
                this.bookmarks = value;
            }
        }
    }
}