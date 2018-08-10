using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public interface IBeerService
    {
        void CreateBeerUser(string clientId, GamerType gamerType, string pseudonym);
        BeerUser GetBeerUserById(int id);
        BeerUser GetBeerUserByClientId(string clientId);
        List<BeerUser> GetAllBeerUsers();
        void UpdateBeerUserInformations(BeerUser beerUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="weapon">The weapon of the user.</param>
        void UpdateBeerUserCharacteristics(BeerUser beerUser, Weapon weapon);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beerUser"></param>
        /// <param name="weapon">The weapon of the user.</param>
        BeerUser UpdateBeerUserAddExperienceAndMoney(BeerUser beerUser, Weapon weapon);
        List<BeerUser> RemoveBeerUserFromBeerUsersList(BeerUser beerUser, List<BeerUser> beerUsers);

        GamerType GetGamerTypeByName(string gamerTypeName);
        List<GamerType> GetAllGamerTypes();
        List<string> GetAllGamerTypeNames();

        Weapon GetWeaponById(int weaponId);
        List<Weapon> GetWeaponsByWeaponType(WeaponType weaponType);
        List<Weapon> GetWeaponsByWeaponTypeWithoutWeaponsBoughtByUser(WeaponType weaponType, List<Weapon> userWeapons);

        void AddUserWeapon(UserWeapon userWeapon);
        UserWeapon GetUserWeaponById(int userWeaponId);
        void BuyWeapon(BeerUser beerUser, int weaponId);
        List<UserWeapon> GetUserWeapons(BeerUser beerUser);
        UserWeapon GetUserWeaponInUse(BeerUser beerUser);
        List<Weapon> GetUserWeaponsAsListOfWeapon(BeerUser beerUser);
        void UpdateUserWeaponInUse(UserWeapon userWeapon);
        void UpdateUserWeaponInUse(int userWeaponId);
    }
}
