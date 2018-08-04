using BeerService.Infrastructure;
using BeerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public class BeerService
    {
        private readonly DalBeer _context;

        public BeerService()
        {
            _context = new DalBeer();
        }

        public void CreateBeerUser(string clientId, GamerType gamerType, string pseudonym)
        {
            _context.CreateBeerUser(clientId, gamerType, pseudonym);
        }
        public BeerUser GetUserById(int id)
        {
            return _context.GetBeerUserById(id);
        }
        public BeerUser GetBeerUserByClientId(string clientId)
        {
            return _context.GetBeerUserByClientId(clientId);
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
    }
}
