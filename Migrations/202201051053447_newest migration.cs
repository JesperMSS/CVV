namespace CVSITEHT2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newestmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String());
        }
    }
}
