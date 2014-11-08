namespace Bank.Migrations
{
	using BankSimulation.Models;
	using System;
	using System.Collections.Generic;
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
			context.Currencies.Add(currEuro);

			context.SaveChanges();

			Client c1 = new Client("Kuko");
			c1.addAccount(currEuro);
			context.Clients.Add(c1);

			IList<Transaction> defaultTran = new List<Transaction>();

			defaultTran.Add(new Transaction() { idCurrency = 1, amount = 120, idAccountNumber = 1, type = TransactionType.Deposit.ToString() , timestamp = DateTime.Now });
			//defaultTran.Add(new Transaction() { StandardName = "Standard 2", Description = "Second Standard" });
			//defaultTran.Add(new Transaction() { StandardName = "Standard 3", Description = "Third Standard" });

			foreach (Transaction tr in defaultTran)
				context.Transactions.Add(tr);


			context.SaveChanges();

			//context.SaveChanges();
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
