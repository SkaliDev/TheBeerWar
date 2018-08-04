using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize]
    public class BeerWarController : Controller
    {
        // GET: BeerWar
        public ActionResult Index()
        {
            return View();
        }
    }
}