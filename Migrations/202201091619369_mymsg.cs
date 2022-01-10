namespace CVSITEHT2021.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mymsg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessageId = c.Int(nullable: false, identity: true),
                    title = c.String(),
                    content = c.String(),
                    isRead = c.Boolean(nullable: false),
                    Sender = c.String(),
                    CVId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Messages", "CVId", "dbo.CVs");
            DropIndex("dbo.Messages", new[] { "CVId" });
            DropTable("dbo.Messages");
        }
    }
}