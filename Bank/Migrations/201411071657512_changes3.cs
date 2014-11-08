namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "account_idAccountNumber", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "account_idAccountNumber" });
            RenameColumn(table: "dbo.Clients", name: "accounts_idAccountNumber", newName: "idAccountNumber");
            RenameColumn(table: "dbo.Transactions", name: "account_idAccountNumber", newName: "idAccountNumber");
            RenameIndex(table: "dbo.Clients", name: "IX_accounts_idAccountNumber", newName: "IX_idAccountNumber");
            AlterColumn("dbo.Transactions", "idAccountNumber", c => c.Long(nullable: false));
            CreateIndex("dbo.Transactions", "idAccountNumber");
            AddForeignKey("dbo.Transactions", "idAccountNumber", "dbo.BankAccounts", "idAccountNumber", cascadeDelete: false);
            DropColumn("dbo.Clients", "idBankAccount");
            DropColumn("dbo.Transactions", "idAccount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "idAccount", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "idBankAccount", c => c.Long());
            DropForeignKey("dbo.Transactions", "idAccountNumber", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "idAccountNumber" });
            AlterColumn("dbo.Transactions", "idAccountNumber", c => c.Long());
            RenameIndex(table: "dbo.Clients", name: "IX_idAccountNumber", newName: "IX_accounts_idAccountNumber");
            RenameColumn(table: "dbo.Transactions", name: "idAccountNumber", newName: "account_idAccountNumber");
            RenameColumn(table: "dbo.Clients", name: "idAccountNumber", newName: "accounts_idAccountNumber");
            CreateIndex("dbo.Transactions", "account_idAccountNumber");
            AddForeignKey("dbo.Transactions", "account_idAccountNumber", "dbo.BankAccounts", "idAccountNumber");
        }
    }
}
