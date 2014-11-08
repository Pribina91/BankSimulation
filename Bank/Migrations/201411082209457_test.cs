namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        idAccountNumber = c.Long(nullable: false, identity: true),
                        idCurrency = c.Int(nullable: false),
                        balance = c.Decimal(nullable: false, precision: 10, scale: 3),
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
                        rate = c.Decimal(nullable: false, precision: 10, scale: 3),
                        units = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCurrency);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        idClient = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        idAccountNumber = c.Long(),
                    })
                .PrimaryKey(t => t.idClient)
                .ForeignKey("dbo.BankAccounts", t => t.idAccountNumber)
                .Index(t => t.idAccountNumber);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        idTransation = c.Long(nullable: false, identity: true),
                        idAccountNumber = c.Long(nullable: false),
                        idCurrency = c.Int(nullable: false),
                        amount = c.Decimal(nullable: false, precision: 10, scale: 3),
                        type = c.String(),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idTransation)
                .ForeignKey("dbo.BankAccounts", t => t.idAccountNumber, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.idCurrency, cascadeDelete: false)
                .Index(t => t.idAccountNumber)
                .Index(t => t.idCurrency);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "idCurrency", "dbo.Currencies");
            DropForeignKey("dbo.Transactions", "idAccountNumber", "dbo.BankAccounts");
            DropForeignKey("dbo.Clients", "idAccountNumber", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "idCurrency", "dbo.Currencies");
            DropIndex("dbo.Transactions", new[] { "idCurrency" });
            DropIndex("dbo.Transactions", new[] { "idAccountNumber" });
            DropIndex("dbo.Clients", new[] { "idAccountNumber" });
            DropIndex("dbo.BankAccounts", new[] { "idCurrency" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.Currencies");
            DropTable("dbo.BankAccounts");
        }
    }
}
