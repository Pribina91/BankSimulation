namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalRate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Currencies", "rate", c => c.Decimal(nullable: false, precision: 10, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "rate", c => c.Double(nullable: false));
        }
    }
}
