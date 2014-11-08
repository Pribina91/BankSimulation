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
		public long? idAccountNumber { get; set; }
		public virtual BankAccount accounts {get; set;}

		public Client() { }
		public Client(String _name)
		{
			this.name = _name;
		}
		/// <summary>
		/// Tries to add bankAccount to client 
		/// </summary>
		/// <param name="curr">Currency what is used for new account</param>
		/// <returns></returns>
		public Boolean addAccount(Currency curr)//TODO optional parameter for other owner
		{
			if (idAccountNumber == null)
			{
				List <Client> owners = new List<Client>();
				owners.Add(this);


				BankAccount newAccount = new BankAccount(curr,owners);
				this.idAccountNumber = newAccount.idAccountNumber;
				Context c = new Context();
				c.BankAccounts.Add(newAccount);
				c.SaveChanges();
				return true;
			}
			return false;
			
		}
	}
}