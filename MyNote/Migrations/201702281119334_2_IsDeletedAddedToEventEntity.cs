namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2_IsDeletedAddedToEventEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsDeleted");
        }
    }
}
