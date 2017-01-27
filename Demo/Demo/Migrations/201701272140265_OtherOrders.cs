namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "UserOrder_Id", "dbo.UserOrders");
            DropForeignKey("dbo.UserOrders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "UserOrder_Id" });
            DropIndex("dbo.UserOrders", new[] { "User_Id" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            DropTable("dbo.OrderProducts");
            DropTable("dbo.UserOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        UserOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Orders");
            CreateIndex("dbo.UserOrders", "User_Id");
            CreateIndex("dbo.OrderProducts", "UserOrder_Id");
            CreateIndex("dbo.OrderProducts", "Product_Id");
            AddForeignKey("dbo.UserOrders", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OrderProducts", "UserOrder_Id", "dbo.UserOrders", "Id");
            AddForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
