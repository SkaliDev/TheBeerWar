using BeerService.Model.Models;
using BeerService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;

namespace BeerService.Infrastructure
{
    public class DalBeer : IDalBeer
    {
        private BeerContex _context;
    
        public DalBeer()
        {
            _context = new BeerContex();
        }

        //BeerUsers
        public void CreateBeerUser(string clientId, GamerType gamerType, string pseudonym)
        {
            if (GetGamerTypeById(gamerType.Id) == null)
                throw new BeerException("The gamer type doesn't exist.");
            if (GetBeerUserByPseudonym(pseudonym) != null)
                throw new BeerException("The pseudonym " + pseudonym + " is not avaible.");
            var beerUser = new BeerUser();
            beerUser.ClientId = clientId;
            beerUser.GamerType = gamerType;
            beerUser.Pseudonym = pseudonym;
            beerUser.Level = 1;
            beerUser.Experience = 0;
            beerUser.Money = 10;
            beerUser.Attack = gamerType.Attack;
            beerUser.Defense = gamerType.Defense;
            beerUser.Life = gamerType.Defense;
            _context.BeerUsers.Add(beerUser);
            if (_context.SaveChanges() == 0)
                throw new BeerException("An error occured when creating BeerUser.");
        }
        public BeerUser GetBeerUserById(int beerUserId)
        {
            return _context.BeerUsers.FirstOrDefault(u => u.Id == beerUserId);
        }
        public BeerUser GetBeerUserByPseudonym(string pseudonym)
        {
            return _context.BeerUsers.FirstOrDefault(u => u.Pseudonym == pseudonym);
        }
        public BeerUser GetBeerUserByClientId(string clientId)
        {
            return _context.BeerUsers.FirstOrDefault(u => u.ClientId == clientId);
        }
        public List<BeerUser> GetAllBeerUsers()
        {
            return _context.BeerUsers.ToList();
        }
        public BeerUser UpdateBeerUser(BeerUser beerUser)
        {
            var user = _context.BeerUsers.FirstOrDefault(u => u.Id == beerUser.Id);
            user = beerUser;
            if (_context.SaveChanges() < 0)
                throw new BeerException("An error occured when updating BeerUser.");
            else
                return beerUser;
        }
        public void DeleteBeerUser(BeerUser beerUser)
        {
            _context.BeerUsers.Remove(beerUser);
            if (_context.SaveChanges() == 0)
                throw new BeerException("An error occured when deleting BeerUser.");
        }

        //GamerType
        public GamerType GetGamerTypeById(int gamerTypeId)
        {
            return _context.GamerTypes.FirstOrDefault(g => g.Id == gamerTypeId);
        }
        public GamerType GetGamerTypeByName(string gamerTypeName)
        {
            return _context.GamerTypes.FirstOrDefault(g => g.Name == gamerTypeName);
        }
        public List<GamerType> GetAllGamerTypes()
        {
            return _context.GamerTypes.ToList();
        }
        public List<string> GetAllGamerTypeNames()
        {
            return _context.GamerTypes.Select(g => g.Name).ToList();
        }
        
        //Weapons
        public Weapon GetWeaponById(int weaponId)
        {
            return _context.Weapons.FirstOrDefault(w => w.Id == weaponId);
        }
        public Weapon GetWeaponByAttackMore(WeaponType weaponType, int attackMore)
        {
            return _context.Weapons.FirstOrDefault(w => w.AttackMore == attackMore && w.WeaponType.Id == weaponType.Id);
        }
        public List<Weapon> GetWeaponsByWeaponType(WeaponType weaponType)
        {
            return _context.Weapons.Where(w => w.WeaponType.Id == weaponType.Id).ToList();
        }

        //UserWeapons
        public void AddUserWeapon(UserWeapon userWeapon)
        {
            _context.UserWeapons.Add(userWeapon);
            if (_context.SaveChanges() == 0)
                throw new BeerException("An error occured when adding UserWeapon.");
        }
        public UserWeapon GetUserWeaponById(int userWeaponId)
        {
            return _context.UserWeapons.Include(w => w.Weapon).FirstOrDefault(w => w.Id == userWeaponId);
        }
        public List<UserWeapon> GetUserWeapons(BeerUser beerUser)
        {
            return _context.UserWeapons.Where(w => w.User.Id == beerUser.Id).OrderBy(w => w.Weapon.MinimumLevel).ToList();
        }
        public UserWeapon GetUserWeaponInUse(BeerUser beerUser)
        {
            return _context.UserWeapons.Include(w => w.Weapon).FirstOrDefault(w => w.User.Id == beerUser.Id && w.InUse == true);
        }
        public void UpdateUserWeaponInUse(UserWeapon userWeapon)
        {
            var weapons = _context.UserWeapons.Where(w => w.User.Id == userWeapon.User.Id && w.InUse == true).ToList();
            foreach (UserWeapon w in weapons)
            {
                w.InUse = false;
            }
            userWeapon.InUse = true;
            var weapon = _context.UserWeapons.Where(w => w == userWeapon);
            if (_context.SaveChanges() == 0)
                throw new BeerException("An error occured when updating UserWeapon in use.");
        }
        public void DeleteUserWeapon(UserWeapon userWeapon)
        {
            if (userWeapon.InUse == true)
                throw new BeerException("You can't delete a weapon that is in use !");
            _context.UserWeapons.Remove(userWeapon);
            if (_context.SaveChanges() == 0)
                throw new BeerException("An error occured when deleting UserWeapon.");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}