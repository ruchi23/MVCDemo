namespace OrderFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "CreatedOn", a => a.DateTime());
            AddColumn("dbo.Restaurants", "UpdatedOn", a => a.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "UpdatedDate");
            DropColumn("dbo.Restaurants", "CreatedDate");
        }
    }
}
