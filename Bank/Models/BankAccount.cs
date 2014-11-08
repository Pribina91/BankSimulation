using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSimulation.Models
{
	public class BankAccount
	{
		public BankAccount() { }
		public BankAccount(Currency _currency, IEnumerable<Client> _clients)
		{

			balance = 0;
			this.currency = _currency;
			this.idCurrency = _currency.idCurrency;
			this.clients = _clients;
		}

		[Key]
		[Display(Name = "Account Number")]
		public long idAccountNumber { get; set; }
		public int idCurrency { get; set; }
		
		double _balance;
		public double balance
		{
			get { return this._balance; }
			set { _balance = Math.Round( value, Transaction.decimalNumberRound); }
		}

		public virtual Currency currency { get; set; }
		public virtual IEnumerable<Client> clients { get; set; }
		public virtual IEnumerable<Transaction> transactions { get; set; }


		public void deposit(double _depositValue)
		{
			Context db = new Context();
			Transaction t = new Transaction(_depositValue, currency, this,TransactionType.Deposit);
			balance += Math.Round(_depositValue, Transaction.decimalNumberRound);
			db.Transactions.Add(t);

		}
		public void withdraw(double _withdrawValue)
		{
			Context db = new Context();
			Transaction t = new Transaction(_withdrawValue, currency, this, TransactionType.Withdraw);
			balance -= Math.Round(-1 * _withdrawValue, Transaction.decimalNumberRound);
			db.Transactions.Add(t);
		}
		public void transfer(double _transferValue)
		{
			Context db = new Context();

			try
			{
				db.Database.BeginTransaction();
				Transaction t = new Transaction(_transferValue, currency, this, TransactionType.Transfer);
				balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
				db.Transactions.Add(t);
				t = new Transaction(_transferValue, currency, this, TransactionType.Transfer);
				balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
				db.Transactions.Add(t);
				db.SaveChanges();
			}
			catch (Exception)
			{
				db.Dispose(); //TODO check transactions
			}


		}
		private long getNewAccountNumber()
		{
			Context c = new Context();

			var maxAccount = (from bn in c.BankAccounts
								 orderby bn.idAccountNumber descending
								 select bn).First();

			return ++maxAccount.idAccountNumber;
		}

	}
}
