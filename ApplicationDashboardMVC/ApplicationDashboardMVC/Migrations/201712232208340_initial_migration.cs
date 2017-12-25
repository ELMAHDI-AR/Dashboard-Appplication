namespace ApplicationDashboardMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        CustomerEmail = c.String(nullable: false, maxLength: 60),
                        CustomerPhone = c.String(nullable: false, maxLength: 100),
                        CustomerCountry = c.String(nullable: false, maxLength: 100),
                        CustomerImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quatity = c.Int(nullable: false),
                        Order_ID = c.Int(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.Order_ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .Index(t => t.Order_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                        ProductImage = c.String(nullable: false, maxLength: 100),
                        ProductType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.OrderDetails", "Order_ID", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.OrderDetails", new[] { "Product_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_ID" });
            DropIndex("dbo.Order", new[] { "Customer_ID" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
