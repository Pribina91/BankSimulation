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
		public long idAccountNumber { get; set; }
		public int idCurrency { get; set; }
		double _balance;
		public double balance
		{
			get { return this._balance; }
			set { _balance = Math.Round(value, Transaction.decimalNumberRound); }
		}
		public void deposit(double _depositValue)
		{
			Transaction t = new Transaction(_depositValue, idCurrency, idAccountNumber);
			balance += Math.Round(_depositValue, Transaction.decimalNumberRound);

		}
		public void withdraw(double _withdrawValue)
		{
			Transaction t = new Transaction(_withdrawValue, idCurrency, idAccountNumber);
			balance -= Math.Round(-1 * _withdrawValue, Transaction.decimalNumberRound);
		}
		public void transfer(double _transferValue)
		{
			withdraw(_transferValue);
			Transaction t = new Transaction(_transferValue, idCurrency, idAccountNumber);
			balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
			t = new Transaction(_transferValue, idCurrency, idAccountNumber);
			balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
		}


	}
}
