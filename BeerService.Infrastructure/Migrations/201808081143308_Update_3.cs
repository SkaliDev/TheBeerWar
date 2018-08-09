namespace BeerService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerUsers", "MaxExperience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BeerUsers", "MaxExperience");
        }
    }
}
