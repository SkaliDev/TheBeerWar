using BeerService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerService.Infrastructure
{
    public class BeerContex : DbContext
    {
        public BeerContex() : base("BeerDBContex")
        {
        }

        public DbSet<BeerUser> BeerUsers { get; set; }
        public DbSet<GamerType> GamerTypes { get; set; }
        public DbSet<UserWeapon> UserWeapons { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
    }
}