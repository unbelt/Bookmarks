namespace Bookmarks.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Bookmarks.Models;

    public class BookmarkViewModel: BookmarkSummaryViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Url { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}