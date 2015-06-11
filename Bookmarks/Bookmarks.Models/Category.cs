namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Bookmark> bookmarks;
 
        public Category()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Bookmark> Bookmarks
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