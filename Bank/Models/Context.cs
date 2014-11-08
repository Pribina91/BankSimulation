using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankSimulation.Models
{
	public class Context : DbContext
	{

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>().HasOptional(c => c.accounts);
			modelBuilder.Properties<decimal>()
				.Configure(config => config.HasPrecision(10, Transaction.decimalNumber));
		}
	}
}