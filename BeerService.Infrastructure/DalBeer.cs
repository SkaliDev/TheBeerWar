using BeerService.Models;
using BeerService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public void CreateBeerUser(int clientId, GamerType gamerType, string pseudonym)
        {
            if (GetGamerTypeById(gamerType.Id) == null)
                throw new BeerException("The gamer type doesn't exist.");
            if (GetBeerUserByPseudonym(pseudonym) == null)
                throw new BeerException("The pseudonym " + pseudonym + " is not avaible.");
            var beerUser = new BeerUser();
            beerUser.ClientId = clientId;
            beerUser.GamerType = gamerType;
            beerUser.Pseudonym = pseudonym;
            beerUser.Level = 1;
            beerUser.Experience = 0;
            beerUser.Money = 50;
            _context.BeerUsers.Add(beerUser);
            _context.SaveChanges();
        }
        public BeerUser GetBeerUserById(int beerUserId)
        {
            return _context.BeerUsers.FirstOrDefault(u => u.Id == beerUserId);
        }
        public BeerUser GetBeerUserByPseudonym(string pseudonym)
        {
            return _context.BeerUsers.FirstOrDefault(u => u.Pseudonym == pseudonym);
        }
        public List<BeerUser> GetAllBeerUsers()
        {
            return _context.BeerUsers.ToList();
        }
        public BeerUser UpdateBeerUser(BeerUser beerUser)
        {
            var user = _context.BeerUsers.FirstOrDefault(u => u.Id == beerUser.Id);
            user = beerUser;
            if (_context.SaveChanges() > 0)
                return user;
            else
                return null;
        }
        public void DeleteBeerUser(BeerUser beerUser)
        {
            _context.BeerUsers.Remove(beerUser);
            _context.SaveChanges();
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

        //

        //UserWeapons
        public List<UserWeapon> GetAllUserWeapons()
        {
            return _context.UserWeapons.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}