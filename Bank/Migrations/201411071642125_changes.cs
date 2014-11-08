namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "idBankAccount", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "idBankAccount", c => c.Int(nullable: false));
        }
    }
}
