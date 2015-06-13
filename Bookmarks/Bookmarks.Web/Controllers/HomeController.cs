namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Bookmarks.Data.Contracts;

    public class HomeController : BaseController
    {
        private readonly int defaultEntryCount;

        public HomeController(IBookmarkData data)
            : base(data)
        {
            this.defaultEntryCount = 10;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Recent bookmarks";

            var bookmarks = this.BookmarksSummary
                .Take(this.defaultEntryCount).ToList();

            return View(bookmarks);
        }
    }
}