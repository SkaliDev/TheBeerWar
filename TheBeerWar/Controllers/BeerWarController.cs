using BeerService.Model.ViewModels;
using Microsoft.AspNet.Identity;
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
        private readonly BeerService.Service.BeerService _service = new BeerService.Service.BeerService();
        private BeerWarViewModel _model = new BeerWarViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            LoadModel();
            return View(_model);
        }

        private void LoadModel()
        {
            _model.beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
            _model.userWeaponInUse = _service.GetUserWeaponInUse(_model.beerUser);
            _model.userCharacteristics = _service.UserCharacteristicsCalculation(_model.beerUser, _model.userWeaponInUse.Weapon);
            _model.beerUsers = _service.GetAllBeerUsers();
        }
    }
}