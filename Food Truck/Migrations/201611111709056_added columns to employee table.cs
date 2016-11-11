namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnstoemployeetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "EmailAddress", c => c.String());
            AddColumn("dbo.Employees", "AssignedPassword", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "AssignedPassword");
            DropColumn("dbo.Employees", "EmailAddress");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
