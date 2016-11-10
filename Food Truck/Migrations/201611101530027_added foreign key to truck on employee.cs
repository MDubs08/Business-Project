namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeytotruckonemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TruckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "TruckId");
            AddForeignKey("dbo.Employees", "TruckId", "dbo.Trucks", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TruckId", "dbo.Trucks");
            DropIndex("dbo.Employees", new[] { "TruckId" });
            DropColumn("dbo.Employees", "TruckId");
        }
    }
}
