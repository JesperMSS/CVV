namespace CVSITEHT2021.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class sampve2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CVs", "Mail", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.CVs", "Mail", c => c.String(nullable: false));
        }
    }
}
