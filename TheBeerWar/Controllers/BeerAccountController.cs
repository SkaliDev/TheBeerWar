using BeerService.Model.ViewModels;
using BeerService.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BeerService.Service;
using BeerService.Exceptions;

namespace TheBeerWar.Controllers
{
    [Authorize]
    public class BeerAccountController : Controller
    {
        private readonly IBeerService _service = new BeerService.Service.BeerService();
        private CreateUserViewModel _model = new CreateUserViewModel();
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
                return RedirectToAction("Index", "Dashboard");
            
            try
            {
                _model.GamerTypes = _service.GetAllGamerTypes();
                _model.SelectListGamerType = GetSelectListItems(_service.GetAllGamerTypeNames());
            }
            catch (BeerException e)
            {
                _model.ErrorMessage = e.Message;
            }

            return View(_model);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (HttpContext.User.IsInRole("Gamer"))
                return HttpNotFound("Your have already a gamer type.");

            _model = model;
            try
            {
                _model.ErrorMessage = null;
                model.GamerTypes = _service.GetAllGamerTypes();
                model.SelectListGamerType = GetSelectListItems(_service.GetAllGamerTypeNames());

                if (ModelState.IsValid)
                {
                    _service.CreateBeerUser(HttpContext.User.Identity.GetUserId(), _service.GetGamerTypeByName(model.SelectedGamerType), model.Pseudonym);
                    UserManager.AddToRole(HttpContext.User.Identity.GetUserId(), "Gamer");
                }
            }
            catch (BeerException e)
            {
                _model.ErrorMessage = e.Message;
                return RedirectToAction("CreateUser", "BeerAccount");
            }

            return RedirectToAction("Index", "Dashboard");
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