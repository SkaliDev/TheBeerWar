namespace BeerService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserWeapons", "Weapon_Id", "dbo.Weapons");
            DropIndex("dbo.UserWeapons", new[] { "User_Id" });
            DropIndex("dbo.UserWeapons", new[] { "Weapon_Id" });
            AddColumn("dbo.UserWeapons", "InUse", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BeerUsers", "Pseudonym", c => c.String(nullable: false));
            AlterColumn("dbo.UserWeapons", "User_Id", c => c.Int());
            AlterColumn("dbo.UserWeapons", "Weapon_Id", c => c.Int());
            CreateIndex("dbo.UserWeapons", "User_Id");
            CreateIndex("dbo.UserWeapons", "Weapon_Id");
            AddForeignKey("dbo.UserWeapons", "Weapon_Id", "dbo.Weapons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWeapons", "Weapon_Id", "dbo.Weapons");
            DropIndex("dbo.UserWeapons", new[] { "Weapon_Id" });
            DropIndex("dbo.UserWeapons", new[] { "User_Id" });
            AlterColumn("dbo.UserWeapons", "Weapon_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserWeapons", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BeerUsers", "Pseudonym", c => c.String());
            DropColumn("dbo.UserWeapons", "InUse");
            CreateIndex("dbo.UserWeapons", "Weapon_Id");
            CreateIndex("dbo.UserWeapons", "User_Id");
            AddForeignKey("dbo.UserWeapons", "Weapon_Id", "dbo.Weapons", "Id", cascadeDelete: true);
        }
    }
}
