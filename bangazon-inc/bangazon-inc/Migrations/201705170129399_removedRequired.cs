namespace bangazon_inc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Payments", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Products", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            AlterColumn("dbo.Payments", "Customer_CustomerId", c => c.Int());
            AlterColumn("dbo.Products", "Customer_CustomerId", c => c.Int());
            AlterColumn("dbo.OrderDetails", "Order_OrderId", c => c.Int());
            AlterColumn("dbo.OrderDetails", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.Payments", "Customer_CustomerId");
            CreateIndex("dbo.Products", "Customer_CustomerId");
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            CreateIndex("dbo.OrderDetails", "Product_ProductId");
            AddForeignKey("dbo.Payments", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Products", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropIndex("dbo.Products", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Payments", new[] { "Customer_CustomerId" });
            AlterColumn("dbo.OrderDetails", "Product_ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Order_OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Customer_CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Customer_CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "Product_ProductId");
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            CreateIndex("dbo.Products", "Customer_CustomerId");
            CreateIndex("dbo.Payments", "Customer_CustomerId");
            AddForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
