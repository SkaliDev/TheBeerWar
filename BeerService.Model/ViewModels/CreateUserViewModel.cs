using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeerService.Model.ViewModels
{
    public class CreateUserViewModel
    {
        public BeerUser BeerUser { get; set; }
        [Required(ErrorMessage = "The selectedGamerType is required.")]
        public string SelectedGamerType { get; set; }
        public List<GamerType> GamerTypes { get; set; }
        public IEnumerable<SelectListItem> SelectListGamerType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
