namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankAccounts", "balance", c => c.Decimal(nullable: false, precision: 10, scale: 3));
            AlterColumn("dbo.Transactions", "amount", c => c.Decimal(nullable: false, precision: 10, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "amount", c => c.Double(nullable: false));
            AlterColumn("dbo.BankAccounts", "balance", c => c.Double(nullable: false));
        }
    }
}
