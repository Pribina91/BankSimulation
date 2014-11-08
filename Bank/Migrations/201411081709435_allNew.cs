namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allNew : DbMigration
    {
        public override void Up()
        {
			Sql("ALTER TABLE [dbo].[BankAccounts] DROP CONSTRAINT DF__BankAccou__balan__108B795B");
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
