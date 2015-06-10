namespace Bookmarks.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int BookmarkId { get; set; }

        [Required]
        public virtual Bookmark Bookmark { get; set; }
    }
}