namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Bookmark
    {
        private ICollection<Comment> comments;

        public Bookmark()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Url { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}