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
    public class BeerWarController : Controller
    {
        private readonly IBeerService _service = new BeerService.Service.BeerService();
        private BeerWarViewModel _model = new BeerWarViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            LoadModel();
            return View(_model);
        }

        [HttpGet]
        public ActionResult SelectPage(int selectedPage, string search)
        {
            LoadModel();
            _model.SelectedPage = selectedPage;
            _model.Pagination();
            _model.Search = search;
            Search();

            return View("Index", _model);
        }

        [HttpGet]
        public ActionResult ChangePageLeft(int selectedPage, string search)
        {
            LoadModel();
            _model.SelectedPage = selectedPage;
            _model.Search = search;

            _model.SelectedPage--;

            Search();
            return View("Index", _model);
        }

        [HttpGet]
        public ActionResult ChangePageRight(int selectedPage, string search)
        {
            LoadModel();
            _model.SelectedPage = selectedPage;
            _model.Search = search;

            _model.SelectedPage++;

            Search();
            return View("Index", _model);
        }

        [HttpPost]
        public ActionResult Search(BeerWarViewModel model)
        {
            LoadModel();
            _model.SelectedPage = model.SelectedPage;
            _model.Search = model.Search;
            Search();

            return View("Index", _model);
        }

        [HttpGet]
        public ActionResult Fight(int id)
        {
            return View("Index", _model);
        }

        private void Search()
        {
            if (_model.Search != null && _model.Search != "")
            {
                var tmp = _model.beerUsers.Where(u => u.Pseudonym.ToLower().Contains(_model.Search.ToLower())).ToList();
                _model.beerUsers = tmp;
            }
            _model.Pagination();
        }
        private void LoadModel()
        {
            _model.beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
            _model.userWeaponInUse = _service.GetUserWeaponInUse(_model.beerUser);
            _model.beerUser = BeerCalculationService.CharacteristicsCalculation(_model.beerUser, _model.userWeaponInUse.Weapon);
            _model.beerUsers = _service.RemoveBeerUserFromBeerUsersList(_model.beerUser, _service.GetAllBeerUsers());
            _model.Pagination();
            _model.Search = null;
        }
    }
}