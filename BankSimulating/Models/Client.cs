using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankSimulation.Models
{
	public class Client
	{
		
		public int idClient { get; set; }
		public String name { get; set; }

		//public virtual BankAccount accounts {get; set;}
		

		public Client(String _name)
		{
			this.name = _name;
			//accounts = new List<BankAccount>();
		}

		//public void addAccount(Currency curr)
		//{
		//	BankAccount newAccount = new BankAccount();
		//	//newAccount

		//	accounts.Add(newAccount);
		//}
	}
}