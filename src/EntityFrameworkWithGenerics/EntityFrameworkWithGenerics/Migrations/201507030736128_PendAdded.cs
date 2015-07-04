namespace EntityFrameworkWithGenerics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pens",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Weight = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pens");
        }
    }
}
