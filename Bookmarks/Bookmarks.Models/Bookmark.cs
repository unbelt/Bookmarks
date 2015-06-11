namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Bookmark
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Bookmark()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Url { get; set; }

        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        public virtual Category Category { get; set; }

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

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }
    }
}