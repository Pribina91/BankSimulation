using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSimulation.Models
{
	
	public class Transaction
	{
		public static int decimalNumberRound = 3;

		[Key]
		private int idCurrency;
		private long idAccountNumber;
		public double amount;


		public Transaction(double amount, int idCurrency, long idAccountNumber)
		{
			// TODO: Complete member initialization
			this.amount = amount;
			this.idCurrency = idCurrency;
			this.idAccountNumber = idAccountNumber;

		}



	}
}