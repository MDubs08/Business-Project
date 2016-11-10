namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        TruckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Trucks", t => t.TruckId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TruckId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TruckId", "dbo.Trucks");
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "TruckId" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropTable("dbo.Employees");
        }
    }
}
