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
			set { _balance = value; }
		}

		public virtual Currency currency { get; set; }
		public virtual IEnumerable<Client> clients { get; set; }
		public virtual IEnumerable<Transaction> transactions { get; set; }

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void deposit(Context db, decimal _depositValue, TransactionType tt, Currency depositCurrency)
		{
			db.Transactions.Add(new Transaction(_depositValue, depositCurrency, this, tt));
			decimal convertedValue = convertToHomeCurrency(_depositValue, depositCurrency);
			balance += convertedValue; //Math.Round(, Transaction.decimalNumberRound);
			db.SaveChanges();
		}

		private decimal convertToHomeCurrency(decimal value, Currency _currency)
		{
			//at first covert to default currency by division 
			decimal convertedValue = (value / _currency.rate) * _currency.units;
			//at second convert to account currency by multiplication
			convertedValue = (convertedValue * currency.rate) / currency.units;
			return convertedValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void withdraw(Context db, decimal _withdrawValue, TransactionType tt, Currency withdrawCurrency)
		{
			db.Transactions.Add(new Transaction(_withdrawValue, withdrawCurrency, this, tt));
			decimal convertedValue = convertToHomeCurrency(_withdrawValue, withdrawCurrency);
			balance -= convertedValue; //Math.Round(, Transaction.decimalNumberRound);
			db.SaveChanges();

		}
		//[MethodImpl(MethodImplOptions.Synchronized)]
		//public void transfer(Context db, decimal _transferValue)
		//{
		//	var transation = db.Database.BeginTransaction();
		//	try
		//	{
		//		db.Transactions.Add(new Transaction(_transferValue, currency, this, TransactionType.Transfer));
		//		balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
		//		db.Transactions.Add(new Transaction(_transferValue, currency, this, TransactionType.Transfer));
		//		balance -= Math.Round(-1 * _transferValue, Transaction.decimalNumberRound);
		//		db.SaveChanges();
		//		transation.Commit();
		//	}
		//	catch (Exception)
		//	{
		//		//TODO check transactions
		//		transation.Rollback();
		//	}


		//}
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
