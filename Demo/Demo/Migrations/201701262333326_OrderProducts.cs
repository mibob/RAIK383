namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        UserOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.UserOrders", t => t.UserOrder_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.UserOrder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "UserOrder_Id", "dbo.UserOrders");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderProducts", new[] { "UserOrder_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropTable("dbo.OrderProducts");
        }
    }
}
