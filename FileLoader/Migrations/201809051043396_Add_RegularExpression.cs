namespace FileLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RegularExpression : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "RegionId", "dbo.Regions");
            DropIndex("dbo.Areas", new[] { "RegionId" });
            AlterColumn("dbo.Areas", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Areas", "RegionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Areas", "RegionId");
            AddForeignKey("dbo.Areas", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "RegionId", "dbo.Regions");
            DropIndex("dbo.Areas", new[] { "RegionId" });
            AlterColumn("dbo.Regions", "Name", c => c.String());
            AlterColumn("dbo.Areas", "RegionId", c => c.Guid());
            AlterColumn("dbo.Areas", "Name", c => c.String());
            CreateIndex("dbo.Areas", "RegionId");
            AddForeignKey("dbo.Areas", "RegionId", "dbo.Regions", "Id");
        }
    }
}
