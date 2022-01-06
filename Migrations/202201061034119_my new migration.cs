namespace CVSITEHT2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mynewmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CVs", "PrivateProfile", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CVs", "PrivateProfile");
        }
    }
}
