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

			IList<Currency> curr = new List<Currency>();	
			curr.Add(new Currency() {idCurrency =1, name = "EUR", rate = 1, units = 1 });
			curr.Add(new Currency() { idCurrency = 2, name = "USD", rate = 1.254M, units = 1 });
			curr.Add(new Currency() { idCurrency = 3, name = "JPY", rate = 124.2755M, units = 100 });

			foreach (Currency c in curr)
				context.Currencies.AddOrUpdate(c);

			context.SaveChanges();

			IList<BankAccount> bAcc = new List<BankAccount>();
			bAcc.Add(new BankAccount() { idAccountNumber = 1, idCurrency = 1, balance = 100M });
			bAcc.Add(new BankAccount() { idAccountNumber = 2, idCurrency = 1, balance = 25.154M });
			bAcc.Add(new BankAccount() { idAccountNumber = 3, idCurrency = 2, balance = 2148.1M });

			foreach (BankAccount ba in bAcc)
				context.BankAccounts.AddOrUpdate(ba);

			IList<Client> clie = new List<Client>();
			clie.Add(new Client() { name = "Kuko", idAccountNumber = 1, idClient = 1 });
			clie.Add(new Client() { name = "Fero", idAccountNumber = 1, idClient = 2 });
			clie.Add(new Client() { name = "Zuzana", idAccountNumber = 2, idClient = 3 });
			clie.Add(new Client() { name = "Jozef", idAccountNumber = 3, idClient = 4 });

			foreach (Client c in clie)
				context.Clients.AddOrUpdate(c);


			IList<Transaction> defaultTran = new List<Transaction>();

			defaultTran.Add(new Transaction() {idTransation = 1, idCurrency = 1, amount = 120, idAccountNumber = 1, type = TransactionType.Deposit.ToString() , timestamp = DateTime.Now });
			defaultTran.Add(new Transaction() { idTransation = 2, idCurrency = 2, amount = 245.697M, idAccountNumber = 2, type = TransactionType.Withdraw.ToString(), timestamp = DateTime.Now });
			defaultTran.Add(new Transaction() { idTransation = 3, idCurrency = 1, amount = 242.24M, idAccountNumber = 1, type = TransactionType.Transfer.ToString(), timestamp = DateTime.Now });
			defaultTran.Add(new Transaction() { idTransation = 4, idCurrency = 2, amount = 125.7M, idAccountNumber = 2, type = TransactionType.Transfer.ToString(), timestamp = DateTime.Now });

			foreach (Transaction tr in defaultTran)
				context.Transactions.AddOrUpdate(tr);


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
