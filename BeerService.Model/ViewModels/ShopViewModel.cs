using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Model.ViewModels
{
    public class ShopViewModel
    {
        public BeerUser beerUser { get; set; }
        public List<Weapon> UserWeapons { get; set; }
        public List<Weapon> WeaponsToBuy { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
