namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gameStatistics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PastGames",
                c => new
                    {
                        PastGameId = c.Int(nullable: false, identity: true),
                        QuestionsAsked = c.Int(nullable: false),
                        Won = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PastGameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PastGames");
        }
    }
}
