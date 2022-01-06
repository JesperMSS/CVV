namespace CVSITEHT2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CVs", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CVs", "ImagePath");
        }
    }
}
