namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descriptionforfooditem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food_Item", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food_Item", "Description");
        }
    }
}
