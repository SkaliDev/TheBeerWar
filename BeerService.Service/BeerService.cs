using BeerService.Exceptions;
using BeerService.Infrastructure;
using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public class BeerService : IBeerService
    {
        private readonly IDalBeer _context;

        public BeerService()
        {
            _context = new DalBeer();
        }

        public void CreateBeerUser(string clientId, GamerType gamerType, string pseudonym)
        {
            _context.CreateBeerUser(clientId, gamerType, pseudonym);
            var beerUser = _context.GetBeerUserByClientId(clientId);
            var weapon = _context.GetWeaponByAttackMore(gamerType.WeaponType, 2);
            _context.AddUserWeapon(new UserWeapon(beerUser, weapon, true));
        }
        public BeerUser GetBeerUserById(int id)
        {
            return _context.GetBeerUserById(id);
        }
        public BeerUser GetBeerUserByClientId(string clientId)
        {
            return _context.GetBeerUserByClientId(clientId);
        }
        public List<BeerUser> GetAllBeerUsers()
        {
            // Update characteristics of all gamers.
            var beerUsers = _context.GetAllBeerUsers();
            foreach (var u in beerUsers)
            {
                UpdateBeerUserInformations(BeerCalculationService.CharacteristicsCalculation(u, GetUserWeaponInUse(u).Weapon));
            }

            return _context.GetAllBeerUsers();
        }
        public void UpdateBeerUserInformations(BeerUser beerUser)
        {
            _context.UpdateBeerUser(beerUser);
        }
        public void UpdateBeerUserCharacteristics(BeerUser beerUser, Weapon weapon)
        {
            BeerCalculationService.CharacteristicsCalculation(beerUser, weapon);
            _context.UpdateBeerUser(beerUser);
        }
        public BeerUser UpdateBeerUserAddExperienceAndMoney(BeerUser beerUser, Weapon weapon)
        {
            BeerCalculationService.AddExperience(beerUser, weapon);
            beerUser.Money += 10;
            return _context.UpdateBeerUser(beerUser);
        }
        public List<BeerUser> RemoveBeerUserFromBeerUsersList(BeerUser beerUser, List<BeerUser> beerUsers)
        {
            beerUsers.RemoveAll(u => u.Id == beerUser.Id);
            return beerUsers;
        }

        public GamerType GetGamerTypeByName(string gamerTypeName)
        {
            return _context.GetGamerTypeByName(gamerTypeName);
        }
        public List<GamerType> GetAllGamerTypes()
        {
            return _context.GetAllGamerTypes();
        }
        public List<string> GetAllGamerTypeNames()
        {
            return _context.GetAllGamerTypeNames();
        }

        public Weapon GetWeaponById(int weaponId)
        {
            return _context.GetWeaponById(weaponId);
        }
        public List<Weapon> GetWeaponsByWeaponType(WeaponType weaponType)
        {
            return _context.GetWeaponsByWeaponType(weaponType);
        }
        public List<Weapon> GetWeaponsByWeaponTypeWithoutWeaponsBoughtByUser(WeaponType weaponType, List<Weapon> userWeapons)
        {
            var weapons = GetWeaponsByWeaponType(weaponType);
            List<Weapon> weaponsWithoutWeaponsBoughtByUser = new List<Weapon>();
            foreach (Weapon w in weapons)
            {
                if (!userWeapons.Contains(w))
                    weaponsWithoutWeaponsBoughtByUser.Add(w);
            }
            return weaponsWithoutWeaponsBoughtByUser;
        }

        public void AddUserWeapon(UserWeapon userWeapon)
        {
            _context.AddUserWeapon(userWeapon);
        }
        public void BuyWeapon(BeerUser beerUser, int weaponId)
        {
            var weapon = GetWeaponById(weaponId);
            if (beerUser.Money < weapon.Cost)
                throw new BeerException("You doesn't have enought money !");
            if (weapon == null)
                throw new BeerException("Weapon not found !");
            AddUserWeapon(new UserWeapon(beerUser, weapon, false));
            beerUser.Money -= weapon.Cost;
            UpdateBeerUserInformations(beerUser);
        }
        public UserWeapon GetUserWeaponById(int userWeaponId)
        {
            return _context.GetUserWeaponById(userWeaponId);
        }
        public List<UserWeapon> GetUserWeapons(BeerUser beerUser)
        {
            var userWeapons = _context.GetUserWeapons(beerUser);
            if (userWeapons == null || userWeapons.Count == 0)
            {
                var weapon = _context.GetWeaponByAttackMore(beerUser.GamerType.WeaponType, 2);
                UserWeapon userWeapon = new UserWeapon(beerUser, weapon, true);
                AddUserWeapon(userWeapon);
                return _context.GetUserWeapons(beerUser);
            }
            else
                return userWeapons;
        }
        public UserWeapon GetUserWeaponInUse(BeerUser beerUser)
        {
            var userWeapon = _context.GetUserWeaponInUse(beerUser);
            if (userWeapon == null)
            {
                _context.GetWeaponByAttackMore(beerUser.GamerType.WeaponType, 2);
                return _context.GetUserWeaponInUse(beerUser);
            }
            else
                return userWeapon;
        }
        public List<Weapon> GetUserWeaponsAsListOfWeapon(BeerUser beerUser)
        {
            List<Weapon> weapons = new List<Weapon>();
            foreach (UserWeapon uW in GetUserWeapons(beerUser))
            {
                weapons.Add(uW.Weapon);
            }
            return weapons;
        }
        public void UpdateUserWeaponInUse(UserWeapon userWeapon)
        {
            if (userWeapon.Weapon.MinimumLevel > userWeapon.User.Level)
                throw new BeerException("You do not have the enough level yet !");
            _context.UpdateUserWeaponInUse(userWeapon);
            UpdateBeerUserInformations(BeerCalculationService.CharacteristicsCalculation(userWeapon.User, userWeapon.Weapon));
        }
        public void UpdateUserWeaponInUse(int userWeaponId)
        {
            var userWeapon = GetUserWeaponById(userWeaponId);
            if (userWeapon == null)
                throw new BeerException("Can't find the weapon !");
            UpdateUserWeaponInUse(userWeapon);
            UpdateBeerUserInformations(BeerCalculationService.CharacteristicsCalculation(userWeapon.User, userWeapon.Weapon));
        }
        public void DeleteUserWeapon(UserWeapon userWeapon)
        {
            _context.DeleteUserWeapon(userWeapon);
        }
        public void SailWeapon(BeerUser beerUser, int userWeaponId)
        {
            var userWeapon = GetUserWeaponById(userWeaponId);
            beerUser.Money += (userWeapon.Weapon.Cost / 2);
            UpdateBeerUserInformations(beerUser);
            if (userWeapon == null)
                throw new BeerException("Weapon not found !");
            if (userWeapon.InUse == true)
                throw new BeerException("You can't sail a weapon that is in use !");
            DeleteUserWeapon(userWeapon);
        }
    }
}
