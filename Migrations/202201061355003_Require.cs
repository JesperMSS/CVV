namespace CVSITEHT2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Require : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String(nullable: false));
        }
    }
}
