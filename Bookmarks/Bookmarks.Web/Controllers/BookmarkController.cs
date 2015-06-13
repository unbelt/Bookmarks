namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;
    using Bookmarks.Web.ViewModels;

    public class BookmarkController : BaseController
    {
        public BookmarkController(IBookmarkData data)
            : base(data)
        {
            ViewData["Categories"] = this.Data.Categories.All()
                .Project().To<CategoryViewModel>();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bookmark = this.Bookmarks.FirstOrDefault(b => b.Id == id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkViewModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return View(entry);
            }

            Mapper.CreateMap<BookmarkViewModel, Bookmark>();
            var bookmark = Mapper.Map<Bookmark>(entry);

            this.Data.Bookmarks.Add(bookmark);
            this.Data.SaveChanges();

            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var bookmark = this.Bookmarks.FirstOrDefault(b => b.Id == id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookmarkViewModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return View(entry);
            }

            var bookmark = Mapper.Map<Bookmark>(entry);

            this.Data.Bookmarks.Update(bookmark);
            this.Data.SaveChanges();

            return this.RedirectToAction<HomeController>(c => c.Index());

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (this.IsAdmin())
            {
                this.Data.Bookmarks.Delete(id);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}