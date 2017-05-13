namespace bangazon_inc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetupAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(nullable: false),
                        CustomerLastName = c.String(nullable: false),
                        CustomerAddressLine1 = c.String(nullable: false),
                        CustomerAddressLine2 = c.String(),
                        CustomerCity = c.String(nullable: false),
                        CustomerState = c.String(nullable: false),
                        CustomerZipCode = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Order_OrderId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderActive = c.String(),
                        Customer_CustomerId = c.Int(nullable: false),
                        Payment_PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Payments", t => t.Payment_PaymentId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Payment_PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(nullable: false),
                        PaymentAccountNumber = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 255),
                        Image = c.String(),
                        Category_CategoryId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Payments", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Payments", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Orders", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
