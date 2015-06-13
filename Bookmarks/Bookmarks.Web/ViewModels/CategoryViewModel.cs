namespace Bookmarks.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class CategoryViewModel : IMapFrom<Category>
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}