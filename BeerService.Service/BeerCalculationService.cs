using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public static class BeerCalculationService
    {
        public static BeerUser CharacteristicsCalculation(BeerUser beerUser, Weapon weapon)
        {
            beerUser.Attack = (int)(beerUser.GamerType.Attack + (beerUser.GamerType.Attack / 11) + weapon.AttackMore + (beerUser.Attack * 2.5));
            beerUser.Defense = (int)(beerUser.GamerType.Defense + (beerUser.GamerType.Defense / 9.60) + (beerUser.Attack * 2.5));
            beerUser.Life = (int)(beerUser.GamerType.Defense + (beerUser.GamerType.Defense / 10) + (beerUser.Attack * 2.5));
            beerUser.MaxExperience = (int)(beerUser.Level * 10.6);

            return beerUser;
        }
        public static BeerUser AddExperience(BeerUser beerUser, Weapon weapon, int experience)
        {
            beerUser.Experience += experience;
            if (beerUser.Experience >= beerUser.MaxExperience)
            {
                beerUser.Level ++;
                beerUser.Experience = 0;
                beerUser = CharacteristicsCalculation(beerUser, weapon);
            }
            return beerUser;
        }
    }
}
