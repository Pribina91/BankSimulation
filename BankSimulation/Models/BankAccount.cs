using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSimulation.Models
{
	public class BankAccount
	{
		public BankAccount()
		{

		}

		[Key]
		long idAccountNumber { get; set; }
		int idCurrency { get; set; }
		double _balance;
		double balance
		{
			get { return this._balance; }
			set { _balance = Math.Round(value, Transaction.decimalNumberRound); }
		}
		void deposit(double _depositValue)
		{
			Transaction t = new Transaction(_depositValue, idCurrency, idAccountNumber);
			balance += Math.Round(_depositValue, Transaction.decimalNumberRound);

		}




	}
}
