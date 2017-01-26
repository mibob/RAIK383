namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserOrders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserOrders", "ProductId", "dbo.Products");
            DropIndex("dbo.UserOrders", new[] { "ProductId" });
            DropIndex("dbo.UserOrders", new[] { "UserId" });
            DropTable("dbo.UserOrders");
        }
    }
}
