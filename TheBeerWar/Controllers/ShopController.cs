using BeerService.Exceptions;
using BeerService.Model.ViewModels;
using BeerService.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize(Roles = "Gamer")]
    public class ShopController : Controller
    {
        private readonly IBeerService _service = new BeerService.Service.BeerService();
        private ShopViewModel _model = new ShopViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            LoadModel();
            return View(_model);
        }

        [HttpGet]
        public ActionResult BuyWeapon(int id)
        {
            LoadModel();
            try
            {
                _service.BuyWeapon(_model.beerUser, id);
                LoadModel();
                _model.SuccessMessage = "The weapon is bought !";
                _model.ErrorMessage = null;
            }
            catch (BeerException e)
            {
                _model.SuccessMessage = null;
                _model.ErrorMessage = e.Message;
            }
            return View("Index", _model);
        }

        private void LoadModel()
        {
            _model.beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
            _model.UserWeapons = _service.GetUserWeaponsAsListOfWeapon(_model.beerUser);
            _model.WeaponsToBuy = _service.GetWeaponsByWeaponTypeWithoutWeaponsBoughtByUser(_model.beerUser.GamerType.WeaponType, _model.UserWeapons);
        }
    }
}