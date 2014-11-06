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

	}
}