namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;

    public class BookmarkController : BaseController
    {
        // GET: Bookmark
        public ActionResult Index()
        {
            return View();
        }
    }
}