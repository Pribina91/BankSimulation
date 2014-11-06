using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankSimulation.Models
{
	public class Client
	{
		[Key]
		public int idClient { get; set; }
		public String name { get; set; }

		public List<BankAccount> accounts;
		
		public Client(String _name)
		{
			this.name = _name;
			accounts = new List<BankAccount>();
		}

		public void addAccount(Currency curr)
		{
			BankAccount newAccount = new BankAccount();
			//newAccount

			accounts.Add(newAccount);
		}
	}
}