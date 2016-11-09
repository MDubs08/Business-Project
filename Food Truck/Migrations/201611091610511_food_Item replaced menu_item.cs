namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class food_Itemreplacedmenu_item : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Menu_ItemID", "dbo.Menu_Item");
            DropForeignKey("dbo.OrderDetails", "Menu_ItemID", "dbo.Menu_Item");
            DropIndex("dbo.Ingredients", new[] { "Menu_ItemID" });
            DropIndex("dbo.OrderDetails", new[] { "Menu_ItemID" });
            CreateTable(
                "dbo.Food_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sale_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Ingredients", "Food_ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.Menu_Item", "Food_ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Food_ItemID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredients", "Food_ItemID");
            CreateIndex("dbo.Menu_Item", "Food_ItemID");
            CreateIndex("dbo.OrderDetails", "Food_ItemID");
            AddForeignKey("dbo.Ingredients", "Food_ItemID", "dbo.Food_Item", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Menu_Item", "Food_ItemID", "dbo.Food_Item", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Food_ItemID", "dbo.Food_Item", "ID", cascadeDelete: true);
            DropColumn("dbo.Ingredients", "Menu_ItemID");
            DropColumn("dbo.Menu_Item", "Name");
            DropColumn("dbo.Menu_Item", "Sale_Price");
            DropColumn("dbo.OrderDetails", "Menu_ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Menu_ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.Menu_Item", "Sale_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menu_Item", "Name", c => c.String());
            AddColumn("dbo.Ingredients", "Menu_ItemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "Food_ItemID", "dbo.Food_Item");
            DropForeignKey("dbo.Menu_Item", "Food_ItemID", "dbo.Food_Item");
            DropForeignKey("dbo.Ingredients", "Food_ItemID", "dbo.Food_Item");
            DropIndex("dbo.OrderDetails", new[] { "Food_ItemID" });
            DropIndex("dbo.Menu_Item", new[] { "Food_ItemID" });
            DropIndex("dbo.Ingredients", new[] { "Food_ItemID" });
            DropColumn("dbo.OrderDetails", "Food_ItemID");
            DropColumn("dbo.Menu_Item", "Food_ItemID");
            DropColumn("dbo.Ingredients", "Food_ItemID");
            DropTable("dbo.Food_Item");
            CreateIndex("dbo.OrderDetails", "Menu_ItemID");
            CreateIndex("dbo.Ingredients", "Menu_ItemID");
            AddForeignKey("dbo.OrderDetails", "Menu_ItemID", "dbo.Menu_Item", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "Menu_ItemID", "dbo.Menu_Item", "ID", cascadeDelete: true);
        }
    }
}
