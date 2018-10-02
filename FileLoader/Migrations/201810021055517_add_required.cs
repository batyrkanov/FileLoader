namespace FileLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Areas", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regions", "Name", c => c.String());
            AlterColumn("dbo.Areas", "Name", c => c.String());
        }
    }
}
