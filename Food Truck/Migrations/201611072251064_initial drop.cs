namespace Food_Truck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdrop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street_Number = c.Int(nullable: false),
                        Street_Name = c.String(),
                        CityID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        ZipcodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: true)
                .ForeignKey("dbo.Zipcodes", t => t.ZipcodeID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.StateID)
                .Index(t => t.ZipcodeID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Zipcodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InventoryID = c.Int(nullable: false),
                        Menu_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Menu_Item", t => t.Menu_ItemID, cascadeDelete: true)
                .Index(t => t.InventoryID)
                .Index(t => t.Menu_ItemID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Purchase_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purchase_Date = c.DateTime(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        inStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sale_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TruckID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: false)
                .Index(t => t.TruckID);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Menu_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu_Item", t => t.Menu_ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.Menu_ItemID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScheduleLocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TruckID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: true)
                .Index(t => t.TruckID)
                .Index(t => t.LocationID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.TruckInventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        TruckID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: true)
                .Index(t => t.InventoryID)
                .Index(t => t.TruckID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TruckInventories", "TruckID", "dbo.Trucks");
            DropForeignKey("dbo.TruckInventories", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.ScheduleLocations", "TruckID", "dbo.Trucks");
            DropForeignKey("dbo.ScheduleLocations", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleLocations", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Menu_ItemID", "dbo.Menu_Item");
            DropForeignKey("dbo.Orders", "TruckID", "dbo.Trucks");
            DropForeignKey("dbo.Trucks", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Locations", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Ingredients", "Menu_ItemID", "dbo.Menu_Item");
            DropForeignKey("dbo.Menu_Item", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Ingredients", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.Addresses", "ZipcodeID", "dbo.Zipcodes");
            DropForeignKey("dbo.Addresses", "StateID", "dbo.States");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TruckInventories", new[] { "TruckID" });
            DropIndex("dbo.TruckInventories", new[] { "InventoryID" });
            DropIndex("dbo.ScheduleLocations", new[] { "ScheduleID" });
            DropIndex("dbo.ScheduleLocations", new[] { "LocationID" });
            DropIndex("dbo.ScheduleLocations", new[] { "TruckID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderDetails", new[] { "Menu_ItemID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Trucks", new[] { "MenuID" });
            DropIndex("dbo.Orders", new[] { "TruckID" });
            DropIndex("dbo.Locations", new[] { "AddressID" });
            DropIndex("dbo.Menu_Item", new[] { "MenuID" });
            DropIndex("dbo.Ingredients", new[] { "Menu_ItemID" });
            DropIndex("dbo.Ingredients", new[] { "InventoryID" });
            DropIndex("dbo.Addresses", new[] { "ZipcodeID" });
            DropIndex("dbo.Addresses", new[] { "StateID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TruckInventories");
            DropTable("dbo.ScheduleLocations");
            DropTable("dbo.Schedules");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Trucks");
            DropTable("dbo.Orders");
            DropTable("dbo.Locations");
            DropTable("dbo.Menus");
            DropTable("dbo.Menu_Item");
            DropTable("dbo.Inventories");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Zipcodes");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
