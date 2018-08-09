namespace BeerService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerUsers", "Attack", c => c.Int(nullable: false));
            AddColumn("dbo.BeerUsers", "Defense", c => c.Int(nullable: false));
            AddColumn("dbo.BeerUsers", "Life", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BeerUsers", "Life");
            DropColumn("dbo.BeerUsers", "Defense");
            DropColumn("dbo.BeerUsers", "Attack");
        }
    }
}
