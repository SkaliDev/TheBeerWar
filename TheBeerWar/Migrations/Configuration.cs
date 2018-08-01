namespace TheBeerWar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TheBeerWar.Models.BeerModels.BeerDBContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheBeerWar.Models.BeerModels.BeerDBContex context)
        {
            // Weapon Type
            context.WeaponTypes.AddOrUpdate(
                new Models.BeerModels.WeaponType { NameType = "Arc" },
                new Models.BeerModels.WeaponType { NameType = "Bâton" },
                new Models.BeerModels.WeaponType { NameType = "Epée" }
            );

            // Gamer Type
            context.GamerTypes.AddOrUpdate(
                new Models.BeerModels.GamerType { Name = "Archer", Attack = 50, Defense = 50, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc")},
                new Models.BeerModels.GamerType { Name = "Sorcier", Attack = 70, Defense = 30, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton")},
                new Models.BeerModels.GamerType { Name = "Guerrier", Attack = 30, Defense = 70, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée")}
            );

            // Weapons
            context.Weapons.AddOrUpdate(
                // Begin ARC
                new Models.BeerModels.Weapon { Name = "Arc basique", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc du jour", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc de la nuit", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc bambi", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc pils", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc grimbergen blonde", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc grimbergen double", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc grimbergen triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay dorée", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                // End ARC

                // Begin BATON
                new Models.BeerModels.Weapon { Name = "Bâton basique", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton du jour", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton de la nuit", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton bambi", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton pils", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton grimbergen blonde", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton grimbergen double", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton grimbergen triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton chimay dorée", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                new Models.BeerModels.Weapon { Name = "Bâton chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Bâton") },
                // End BATON

                // Begin EPEE
                new Models.BeerModels.Weapon { Name = "Epée basique", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée du jour", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée de la nuit", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée bambi", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée pils", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée grimbergen blonde", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée grimbergen double", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée grimbergen triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée chimay dorée", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") },
                new Models.BeerModels.Weapon { Name = "Epée chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Epée") }
                // End EPEE
            );
        }
    }
}
