namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Single(nullable: false),
                        Body = c.String(),
                        RestaurantId = c.Int(nullable: false),
                        ClassRestaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRestaurants", t => t.ClassRestaurant_Id)
                .Index(t => t.ClassRestaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ClassRestaurant_Id", "dbo.ClassRestaurants");
            DropIndex("dbo.Reviews", new[] { "ClassRestaurant_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.ClassRestaurants");
        }
    }
}
