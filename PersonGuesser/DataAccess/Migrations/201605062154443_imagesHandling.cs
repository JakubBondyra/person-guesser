namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesHandling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Image");
        }
    }
}
