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
                        CreatedOn = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserOrders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserOrders", new[] { "User_Id" });
            DropTable("dbo.UserOrders");
        }
    }
}
