using BeerService.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public static class BeerCalculationService
    {
        private static Random _rnd = new Random();

        /// <summary>
        /// Calcul of Attack, Defense, Life and MaxExperience of a user.
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static BeerUser CharacteristicsCalculation(BeerUser beerUser, Weapon weapon)
        {
            beerUser.Attack = (int)(beerUser.GamerType.Attack + (beerUser.GamerType.Attack / 11) + weapon.AttackMore + ((beerUser.GamerType.Attack + (beerUser.Level * 3.5)) * 1.3));
            beerUser.Defense = (int)(beerUser.GamerType.Defense + (beerUser.GamerType.Defense / 9.60) + ((beerUser.GamerType.Defense + (beerUser.Level * 3.5)) * 1.3));
            beerUser.Life = (int)(beerUser.GamerType.Life + (beerUser.GamerType.Life / 10) + ((beerUser.GamerType.Life + (beerUser.Level * 3.5)) * 1.3));
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
                beerUser.Level++;
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
            bool result = false;
            bool turn = true; // True == beerUser && False == beerUserEnemy
            int beerUserLife = beerUser.Life;
            int beerUserEnemyLife = beerUserEnemy.Life;

            do
            {
                if (randomBool())
                {
                    if (turn)
                        beerUserEnemyLife -= beerUser.Attack - (int)(beerUserEnemy.Defense * 0.8);
                    else
                        beerUserLife -= beerUserEnemy.Attack - (int)(beerUser.Defense * 0.8);
                }

                turn = !turn;
            } while (beerUserLife > 0 && beerUserEnemyLife > 0);

            if (beerUserLife <= 0) // beerUser lost
                result = false;
            else
                result = true;

            return result;
        }
        private static bool randomBool()
        {
            int i = _rnd.Next(1, 101);
            if (i > 51)
                return true;
            else
                return false;
        }
    }
}
