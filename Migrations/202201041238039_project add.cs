namespace CVSITEHT2021.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class projectadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    CreatedBy = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ProjectCVs",
                c => new
                {
                    Project_ID = c.Int(nullable: false),
                    CV_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Project_ID, t.CV_id })
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.CVs", t => t.CV_id, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.CV_id);

            AddColumn("dbo.CVs", "Name", c => c.String(nullable: false));
            AddColumn("dbo.CVs", "PhoneNumber", c => c.String());
            AddColumn("dbo.CVs", "Mail", c => c.String(nullable: false));
            AddColumn("dbo.CVs", "Competences", c => c.String());
            DropColumn("dbo.CVs", "competances");
        }

        public override void Down()
        {
            AddColumn("dbo.CVs", "competances", c => c.String());
            DropForeignKey("dbo.ProjectCVs", "CV_id", "dbo.CVs");
            DropForeignKey("dbo.ProjectCVs", "Project_ID", "dbo.Projects");
            DropIndex("dbo.ProjectCVs", new[] { "CV_id" });
            DropIndex("dbo.ProjectCVs", new[] { "Project_ID" });
            DropColumn("dbo.CVs", "Competences");
            DropColumn("dbo.CVs", "Mail");
            DropColumn("dbo.CVs", "PhoneNumber");
            DropColumn("dbo.CVs", "Name");
            DropTable("dbo.ProjectCVs");
            DropTable("dbo.Projects");
        }
    }
}
