namespace Bookmarks.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BaseController : Controller
    {
        private const string ControllerString = "Controller";

        public BaseController()
        {
        }

        public BaseController(IBookmarkData data)
        {
            this.Data = data;
        }

        public IBookmarkData Data { get; set; }

        [ChildActionOnly]
        public IQueryable<User> GetUsersInRole(string roleName)
        {
            var userRolesId = new RoleManager<IdentityRole>(this.Data.Context.RoleStore)
                .FindByName(roleName).Users.Select(r => r.UserId);

            var users = this.Data.Users.All()
                .Where(u => userRolesId.Contains(u.Id));

            return users;
        }

        [ChildActionOnly]
        protected ActionResult RedirectToAction<T>(Expression<Action<T>> action) where T : Controller
        {
            var methodName = ((MethodCallExpression)action.Body).Method.Name;
            var controllerName = typeof(T).Name.Replace(ControllerString, string.Empty);

            return RedirectToAction(methodName, controllerName);
        }
    }
}