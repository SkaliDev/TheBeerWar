namespace BeerService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeerUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Money = c.Int(nullable: false),
                        Pseudonym = c.String(nullable: false),
                        GamerType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamerTypes", t => t.GamerType_Id)
                .Index(t => t.GamerType_Id);
            
            CreateTable(
                "dbo.GamerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Attack = c.Int(nullable: false),
                        Defense = c.Int(nullable: false),
                        Life = c.Int(nullable: false),
                        WeaponType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeaponTypes", t => t.WeaponType_Id)
                .Index(t => t.WeaponType_Id);
            
            CreateTable(
                "dbo.WeaponTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWeapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InUse = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                        Weapon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeerUsers", t => t.User_Id)
                .ForeignKey("dbo.Weapons", t => t.Weapon_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Weapon_Id);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MinimumLevel = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        AttackMore = c.Int(nullable: false),
                        WeaponType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeaponTypes", t => t.WeaponType_Id)
                .Index(t => t.WeaponType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWeapons", "Weapon_Id", "dbo.Weapons");
            DropForeignKey("dbo.Weapons", "WeaponType_Id", "dbo.WeaponTypes");
            DropForeignKey("dbo.UserWeapons", "User_Id", "dbo.BeerUsers");
            DropForeignKey("dbo.BeerUsers", "GamerType_Id", "dbo.GamerTypes");
            DropForeignKey("dbo.GamerTypes", "WeaponType_Id", "dbo.WeaponTypes");
            DropIndex("dbo.Weapons", new[] { "WeaponType_Id" });
            DropIndex("dbo.UserWeapons", new[] { "Weapon_Id" });
            DropIndex("dbo.UserWeapons", new[] { "User_Id" });
            DropIndex("dbo.GamerTypes", new[] { "WeaponType_Id" });
            DropIndex("dbo.BeerUsers", new[] { "GamerType_Id" });
            DropTable("dbo.Weapons");
            DropTable("dbo.UserWeapons");
            DropTable("dbo.WeaponTypes");
            DropTable("dbo.GamerTypes");
            DropTable("dbo.BeerUsers");
        }
    }
}
