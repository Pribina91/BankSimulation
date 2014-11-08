using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSimulation.Models
{
	public enum TransactionType{Deposit,Withdraw,Transfer}
	
	public class Transaction
	{
		public static Byte decimalNumber = 3;
		public Transaction() {
			this.timestamp = DateTime.Now;
		}
		[Key]
		public long idTransation { get; set; }
		public long idAccountNumber { get; set; }
		public int idCurrency { get; set; }
		public decimal amount { get; set; }
		public String type { get; set; }
		public DateTime timestamp { get; set; }

		public virtual BankAccount accountNumber { get; set; }
		public virtual Currency currency { get; set; }

		public Transaction(decimal _transferValue, Currency _currency, BankAccount _account,TransactionType _transactionType)
		{
			// TODO: Complete member initialization
			this.amount = _transferValue;
			this.currency = _currency;
			this.idCurrency = _currency.idCurrency;
			this.accountNumber = _account;
			this.idAccountNumber = _account.idAccountNumber;
			this.timestamp = DateTime.Now;
			this.type = _transactionType.ToString();
		}



	}
}