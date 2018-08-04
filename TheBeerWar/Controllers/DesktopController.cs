using BeerService.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize(Roles = "Gamer")]
    public class DesktopController : Controller
    {
        private readonly BeerService.Service.BeerService _service = new BeerService.Service.BeerService();
        private BeerUser beerUser;

        public DesktopController()
        {
            beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}