using BeerService.Exceptions;
using BeerService.Model.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize(Roles = "Gamer")]
    public class DashboardController : Controller
    {
        private readonly BeerService.Service.BeerService _service = new BeerService.Service.BeerService();
        private DashboardViewModel _model = new DashboardViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            LoadModel();
            return View(_model);
        }

        [HttpGet]
        public ActionResult SelectWeapon(int id)
        {
            LoadModel();
            try
            {

                LoadModel();
                _model.SuccessMessage = "The weapon in use changed succefuly !";
                _model.ErrorMessage = null;
                return View("Index", _model);
            }
            catch (BeerException e)
            {
                _model.SuccessMessage = null;
                _model.ErrorMessage = e.Message;
                return View("Index", _model);
            }
        }

        private void LoadModel()
        {
            _model.beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
            _model.userWeapons = _service.GetUserWeapons(_model.beerUser);
            _model.userWeaponInUse = _service.GetUserWeaponInUse(_model.beerUser);
            _model.userCharacteristics = _service.UserCharacteristicsCalculation(_model.beerUser, _model.userWeaponInUse.Weapon);
        }
    }
}