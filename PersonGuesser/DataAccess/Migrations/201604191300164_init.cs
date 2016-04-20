namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        YesCount = c.Int(nullable: false),
                        NoCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.QuestionId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Unforgiveable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "PersonId", "dbo.People");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "PersonId" });
            DropTable("dbo.Questions");
            DropTable("dbo.People");
            DropTable("dbo.Answers");
        }
    }
}
