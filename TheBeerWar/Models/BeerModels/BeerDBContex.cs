using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheBeerWar.Models.BeerModels
{
    public class BeerDBContex : DbContext
    {
        public BeerDBContex() : base("BeerDBContex")
        {
        }

        public DbSet<BeerUser> BeerUsers { get; set; }
        public DbSet<GamerType> GamerTypes { get; set; }
        public DbSet<UserWeapon> UserWeapons { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
    }
}