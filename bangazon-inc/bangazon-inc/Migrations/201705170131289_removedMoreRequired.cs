namespace bangazon_inc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedMoreRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Orders", new[] { "Payment_PaymentId" });
            AlterColumn("dbo.Orders", "Customer_CustomerId", c => c.Int());
            AlterColumn("dbo.Orders", "Payment_PaymentId", c => c.Int());
            CreateIndex("dbo.Orders", "Customer_CustomerId");
            CreateIndex("dbo.Orders", "Payment_PaymentId");
            AddForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments", "PaymentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            AlterColumn("dbo.Orders", "Payment_PaymentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Customer_CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Payment_PaymentId");
            CreateIndex("dbo.Orders", "Customer_CustomerId");
            AddForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments", "PaymentId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
