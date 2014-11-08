namespace Bank.Migrations
{
	using BankSimulation.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankSimulation.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BankSimulation.Models.Context context)
        {
			
			Currency currEuro = new Currency("EUR", 1, 1);
			context.Currencies.AddOrUpdate(currEuro);
			
			Currency currUSD = new Currency("USD", 1.25, 1);
			context.Currencies.AddOrUpdate(currUSD);

			context.SaveChanges();
			Client c1 = new Client("Kuko");
			c1.addAccount(currEuro);
			context.Clients.AddOrUpdate(c1);
			
			context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
