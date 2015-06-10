﻿namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int Count { get; set; }

        public int BookmarkId { get; set; }

        [Required]
        public virtual Bookmark Bookmark { get; set; }

        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}