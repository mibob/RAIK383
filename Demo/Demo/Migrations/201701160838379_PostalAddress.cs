namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostalAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PostalAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PostalAddress");
        }
    }
}
