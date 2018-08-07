using BeerService.Model.ViewModels;
using BeerService.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize]
    public class BeerAccountController : Controller
    {
        private readonly BeerService.Service.BeerService _service = new BeerService.Service.BeerService();
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

        [HttpGet]
        public ActionResult CreateUser()
        {
            if (HttpContext.User.IsInRole("Gamer"))
                return RedirectToAction("Index", "Desktop");

            var model = new CreateUserViewModel();
            model.GamerTypes = _service.GetAllGamerTypes();
            
            model.SelectListGamerType = GetSelectListItems(_service.GetAllGamerTypeNames());

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (HttpContext.User.IsInRole("Gamer"))
                return HttpNotFound("Your have already a gamer type.");

            model.GamerTypes = _service.GetAllGamerTypes();
            model.SelectListGamerType = GetSelectListItems(_service.GetAllGamerTypeNames());

            if (ModelState.IsValid)
            {
                _service.CreateBeerUser(HttpContext.User.Identity.GetUserId(), _service.GetGamerTypeByName(model.SelectedGamerType), model.Pseudonym);
                UserManager.AddToRole(HttpContext.User.Identity.GetUserId(), "Gamer");
            }

            return RedirectToAction("Index", "Desktop");
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}