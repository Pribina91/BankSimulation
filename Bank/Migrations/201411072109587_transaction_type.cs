namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "type");
        }
    }
}
