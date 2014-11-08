namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        idAccountNumber = c.Long(nullable: false, identity: true),
                        idCurrency = c.Int(nullable: false),
                        balance = c.Double(nullable: false,defaultValue:0),
                    })
                .PrimaryKey(t => t.idAccountNumber)
                .ForeignKey("dbo.Currencies", t => t.idCurrency, cascadeDelete: true)
                .Index(t => t.idCurrency);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        idCurrency = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        rate = c.Double(nullable: false),
                        units = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCurrency);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        idClient = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        idBankAccount = c.Int(nullable: true),
                        accounts_idAccountNumber = c.Long(),
                    })
                .PrimaryKey(t => t.idClient)
                .ForeignKey("dbo.BankAccounts", t => t.accounts_idAccountNumber)
                .Index(t => t.accounts_idAccountNumber);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        idTransation = c.Long(nullable: false, identity: true),
                        idAccount = c.Int(nullable: false),
                        idCurrency = c.Int(nullable: false),
                        amount = c.Double(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        account_idAccountNumber = c.Long(),
                    })
                .PrimaryKey(t => t.idTransation)
                .ForeignKey("dbo.BankAccounts", t => t.account_idAccountNumber)
                .ForeignKey("dbo.Currencies", t => t.idCurrency, cascadeDelete: true)
                .Index(t => t.idCurrency)
                .Index(t => t.account_idAccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "idCurrency", "dbo.Currencies");
            DropForeignKey("dbo.Transactions", "account_idAccountNumber", "dbo.BankAccounts");
            DropForeignKey("dbo.Clients", "accounts_idAccountNumber", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "idCurrency", "dbo.Currencies");
            DropIndex("dbo.Transactions", new[] { "account_idAccountNumber" });
            DropIndex("dbo.Transactions", new[] { "idCurrency" });
            DropIndex("dbo.Clients", new[] { "accounts_idAccountNumber" });
            DropIndex("dbo.BankAccounts", new[] { "idCurrency" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.Currencies");
            DropTable("dbo.BankAccounts");
        }
    }
}
