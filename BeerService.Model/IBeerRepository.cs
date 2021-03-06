﻿using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Models
{
    public interface IBeerRepository : IDisposable
    {
        void CreateBeerUser(int clientId, GamerType gamerType, string pseudo);
        BeerUser GetBeerUserById(int beerUserId);
        BeerUser GetBeerUserByPseudonym(string pseudo);
        List<BeerUser> GetAllBeerUsers();
        BeerUser UpdateBeerUser(BeerUser beerUser);
        void DeleteBeerUser(BeerUser beerUser);

        GamerType GetGamerTypeById(int gamerTypeId);
        GamerType GetGamerTypeByName(string gamerTypeName);
        List<GamerType> GetAllGamerTypes();

        /// <summary>
        /// Return all weapons of one user.
        /// </summary>
        /// <returns></returns>
        List<UserWeapon> GetAllUserWeapons();
    }
}
