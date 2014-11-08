using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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

		decimal _balance;
		public decimal balance
		{
			get { return this._balance; }
			set { _balance = Math.Round(value, Transaction.decimalNumberRound); }
		}

		public virtual Currency currency { get; set; }
		public virtual IEnumerable<Client> clients { get; set; }
		public virtual IEnumerable<Transaction> transactions { get; set; }

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void deposit(Context db, decimal _depositValue)
		{
			db.Transactions.Add(new Transaction(_depositValue, currency, this, TransactionType.Deposit));
			balance += Math.Round(_depositValue, Transaction.decimalNumberRound);
			db.SaveChanges();
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void withdraw(Context db, decimal _withdrawValue)
		{
			db.Transactions.Add(new Transaction(_withdrawValue, currency, this, TransactionType.Withdraw));
			balance -= Math.Round(_withdrawValue, Transaction.decimalNumberRound);
			db.SaveChanges();
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void transfer(Context db, decimal _transferValue)
		{
			try
			{
				db.Database.BeginTransaction();
				db.Transactions.Add(new Transaction(_transferValue, currency, this, TransactionType.Transfer));
				balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
				db.Transactions.Add( new Transaction(_transferValue, currency, this, TransactionType.Transfer));
				balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
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
