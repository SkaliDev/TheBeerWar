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
                new Models.BeerModels.WeaponType { NameType = "B�ton" },
                new Models.BeerModels.WeaponType { NameType = "Ep�e" }
            );

            // Gamer Type
            context.GamerTypes.AddOrUpdate(
                new Models.BeerModels.GamerType { Name = "Archer", Attack = 50, Defense = 50, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc")},
                new Models.BeerModels.GamerType { Name = "Sorcier", Attack = 70, Defense = 30, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton")},
                new Models.BeerModels.GamerType { Name = "Guerrier", Attack = 30, Defense = 70, Life = 100, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e")}
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
                new Models.BeerModels.Weapon { Name = "Arc chimay dor�e", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                new Models.BeerModels.Weapon { Name = "Arc chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Arc") },
                // End ARC

                // Begin BATON
                new Models.BeerModels.Weapon { Name = "B�ton basique", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton du jour", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton de la nuit", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton bambi", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton pils", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton grimbergen blonde", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton grimbergen double", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton grimbergen triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton chimay dor�e", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                new Models.BeerModels.Weapon { Name = "B�ton chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "B�ton") },
                // End BATON

                // Begin EPEE
                new Models.BeerModels.Weapon { Name = "Ep�e basique", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e du jour", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e de la nuit", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e bambi", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e pils", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e grimbergen blonde", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e grimbergen double", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e grimbergen triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e chimay dor�e", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e chimay rouge", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e chimay triple", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") },
                new Models.BeerModels.Weapon { Name = "Ep�e chimay bleu", MinimumLevel = 0, Cost = 10, AttackMore = 2, WeaponType = context.WeaponTypes.FirstOrDefault(w => w.NameType == "Ep�e") }
                // End EPEE
            );
        }
    }
}
