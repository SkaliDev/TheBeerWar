using BeerService.Exceptions;
using BeerService.Model.ViewModels;
using BeerService.Service;
using ChatService.Model;
using ChatService.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TheBeerWar.Controllers
{
    [Authorize(Roles = "Gamer")]
    public class DashboardController : Controller
    {
        private readonly IBeerService _service = new BeerService.Service.BeerService();
        private readonly ChatService.Service.ChatService _chatService = new ChatService.Service.ChatService();
        private DashboardViewModel _model = new DashboardViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            LoadModel();
            Session["UserName"] = _model.beerUser.Pseudonym;
            Session["ChatMessages"] = new List<Chat>();
            return View(_model);
        }

        [HttpGet]
        public ActionResult SelectWeapon(int id)
        {
            LoadModel();
            try
            {
                _service.UpdateUserWeaponInUse(id);
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

        [HttpGet]
        public ActionResult SailWeapon(int id)
        {
            LoadModel();
            try
            {
                _service.SailWeapon(_model.beerUser, id);
                LoadModel();
                _model.SuccessMessage = "The weapon is sailed !";
                _model.ErrorMessage = null;
            }
            catch (BeerException e)
            {
                _model.SuccessMessage = null;
                _model.ErrorMessage = e.Message;
            }
            return View("Index", _model);
        }

        [HttpPost]
        public ActionResult Chat(string chatMessage)
        {
            try
            {
                Chat chat = new Chat()
                {
                    UserName = Session["UserName"] as string,
                    Message = chatMessage,
                    Time = DateTime.Now
                };
                _chatService.AddMessage(chat);
                // chatsTmp will take all elements of Session when this will have some more elements
                //List<Chat> chatsTmp = (List<Chat>)Session["ChatMessages"];
                // So solution :
                List<Chat> chatsTmp = new List<Chat>();
                foreach (var cc in (List<Chat>)Session["ChatMessages"])
                {
                    chatsTmp.Add(cc);
                }
                List<Chat> chatsTmp2 = new List<Chat>();
                foreach (var c in _chatService.GetMessages((List<Chat>)Session["ChatMessages"]))
                {
                    chatsTmp2.Add(c);
                }
                Session["ChatMessages"] = null;
                var i = Session["ChatMessages"];
                foreach (var cc in chatsTmp2)
                {
                    if (chatsTmp.Contains(cc))
                    {
                        chatsTmp.First(c => c.Id == cc.Id).ToPrint = false;
                    }
                    else
                    {
                        cc.ToPrint = true;
                        chatsTmp.Add(cc);
                    }
                }
                Session["ChatMessages"] = chatsTmp2;
                return PartialView("Chat", new ChatViewModel(Session["ChatMessages"] as List<Chat>));
            }
            catch (Exception ex)
            {
                //return error to AJAX function
                Response.StatusCode = 500;
                return Content(ex.Message);
            }
        }

        private void LoadModel()
        {
            _model.beerUser = _service.GetBeerUserByClientId(HttpContext.User.Identity.GetUserId());
            _model.userWeapons = _service.GetUserWeapons(_model.beerUser);
            _model.userWeaponInUse = _service.GetUserWeaponInUse(_model.beerUser);
            _model.beerUser = BeerCalculationService.CharacteristicsCalculation(_model.beerUser, _model.userWeaponInUse.Weapon);
        }
    }
}