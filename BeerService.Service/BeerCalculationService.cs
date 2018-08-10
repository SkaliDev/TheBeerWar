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
        /// <summary>
        /// Calcul of Attack, Defense, Life and MaxExperience of a user.
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static BeerUser CharacteristicsCalculation(BeerUser beerUser, Weapon weapon)
        {
            beerUser.Attack = (int)(beerUser.GamerType.Attack + (beerUser.GamerType.Attack / 11) + weapon.AttackMore + (beerUser.GamerType.Attack * 1.3));
            beerUser.Defense = (int)(beerUser.GamerType.Defense + (beerUser.GamerType.Defense / 9.60) + (beerUser.GamerType.Defense * 1.3));
            beerUser.Life = (int)(beerUser.GamerType.Life + (beerUser.GamerType.Life / 10) + (beerUser.GamerType.Life * 1.3));
            if (beerUser.Level >= 50)
                beerUser.MaxExperience = 0;
            else
                beerUser.MaxExperience = (int)(beerUser.Level * 10.6);

            return beerUser;
        }
        /// <summary>
        /// Add experience and calcul the characteristics of the user.
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="weapon"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        public static BeerUser AddExperience(BeerUser beerUser, Weapon weapon)
        {
            if (beerUser.Level < 10)
                beerUser.Experience += beerUser.Level;
            else if (beerUser.Level >= 10 && beerUser.Level < 50)
                beerUser.Experience += beerUser.Level / 10;
            else if (beerUser.Level >= 50)
                beerUser.Experience = 0;

            if (beerUser.Experience >= beerUser.MaxExperience && beerUser.Level < 50)
            {
                beerUser.Level ++;
                beerUser.Experience = 0;
            }

            beerUser = CharacteristicsCalculation(beerUser, weapon);

            return beerUser;
        }
        /// <summary>
        /// Return false if beerUser lose or true if he win.
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="beerUserEnemy"></param>
        /// <returns></returns>
        public static bool Fight(BeerUser beerUser, BeerUser beerUserEnemy)
        {
            bool rep = false;
            bool turn = true; // True == beerUser && False == beerUserEnemy

            do
            {
                
            } while (beerUser.Life > 0 || beerUserEnemy.Life > 0);

            if (beerUser.Life <= 0)
                rep = false;
            else
                rep = true;

            return rep;
        }
        private bool randomBool()
        {
            Boolean boolValue = (UnityEngine.Random.Range(0, 2) == 0);
            if (boolValue == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
