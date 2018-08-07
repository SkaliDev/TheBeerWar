using BeerService.Model.CalculationModels;
using BeerService.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerService.Model.ViewModels
{
    public class DashboardViewModel
    {
        [Required]
        public BeerUser beerUser { get; set; }
        public UserWeapon userWeaponInUse { get; set; }
        public List<UserWeapon> userWeapons { get; set; }
        public UserCharacteristics userCharacteristics { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
