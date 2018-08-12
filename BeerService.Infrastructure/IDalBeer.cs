using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerService.Infrastructure
{
    public interface IDalBeer : IDisposable
    {
        void CreateBeerUser(string clientId, GamerType gamerType, string pseudo);
        BeerUser GetBeerUserById(int beerUserId);
        BeerUser GetBeerUserByPseudonym(string pseudo);
        BeerUser GetBeerUserByClientId(string clientId);
        List<BeerUser> GetAllBeerUsers();
        BeerUser UpdateBeerUser(BeerUser beerUser);
        void DeleteBeerUser(BeerUser beerUser);
        
        GamerType GetGamerTypeById(int gamerTypeId);
        GamerType GetGamerTypeByName(string gamerTypeName);
        List<GamerType> GetAllGamerTypes();
        List<string> GetAllGamerTypeNames();

        Weapon GetWeaponById(int weaponId);
        Weapon GetWeaponByAttackMore(WeaponType weaponType, int attackMore);
        List<Weapon> GetWeaponsByWeaponType(WeaponType weaponType);

        void AddUserWeapon(UserWeapon userWeapon);
        UserWeapon GetUserWeaponById(int userWeaponId);
        /// <summary>
        /// Return all UserWeapon of the BeerUser passed in parameter.
        /// </summary>
        /// <param name="beerUser"></param>
        /// <returns></returns>
        List<UserWeapon> GetUserWeapons(BeerUser beerUser);
        UserWeapon GetUserWeaponInUse(BeerUser beerUser);
        /// <summary>
        /// Check all UserWeapons of the user to put the InUse at false before putting the UserWeapon selected at true.
        /// </summary>
        /// <param name="userWeapon"></param>
        void UpdateUserWeaponInUse(UserWeapon userWeapon);
        void DeleteUserWeapon(UserWeapon userWeapon);
    }
}