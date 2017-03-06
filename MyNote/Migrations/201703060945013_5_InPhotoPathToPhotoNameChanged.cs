namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5_InPhotoPathToPhotoNameChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "PhotoName", c => c.String());
            DropColumn("dbo.Photos", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Path", c => c.String());
            DropColumn("dbo.Photos", "PhotoName");
        }
    }
}
