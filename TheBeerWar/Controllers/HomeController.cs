using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("Gamer"))
                return RedirectToAction("Index", "Desktop");
            else
                return RedirectToAction("CreateUser", "BeerAccount");
        }
    }
}