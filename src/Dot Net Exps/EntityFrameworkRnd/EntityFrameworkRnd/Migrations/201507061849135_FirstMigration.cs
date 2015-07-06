namespace EntityFrameworkRnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                        ObjectiveId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Objectives", t => t.ObjectiveId, cascadeDelete: true)
                .Index(t => t.ObjectiveId);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ObjectiveId = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectiveId);
            
            CreateTable(
                "dbo.PerformanceIndicators",
                c => new
                    {
                        PerformanceIndicatorId = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                        Weight = c.Double(nullable: false),
                        Status = c.String(),
                        IsCompleted = c.Boolean(),
                        IsApproved = c.Boolean(),
                        ActivityId = c.Guid(),
                    })
                .PrimaryKey(t => t.PerformanceIndicatorId)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerformanceIndicators", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Activities", "ObjectiveId", "dbo.Objectives");
            DropIndex("dbo.PerformanceIndicators", new[] { "ActivityId" });
            DropIndex("dbo.Activities", new[] { "ObjectiveId" });
            DropTable("dbo.PerformanceIndicators");
            DropTable("dbo.Objectives");
            DropTable("dbo.Activities");
        }
    }
}
