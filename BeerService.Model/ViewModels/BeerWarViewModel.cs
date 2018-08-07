using BeerService.Model.CalculationModels;
using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Model.ViewModels
{
    public class BeerWarViewModel
    {
        public BeerUser beerUser { get; set; }
        public UserWeapon userWeaponInUse { get; set; }
        public UserCharacteristics userCharacteristics { get; set; }
        public List<BeerUser> beerUsers { get; set; }
    }
}
