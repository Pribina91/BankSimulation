using BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
	public class HomeController : Controller
	{
		Context db = new Context();
		public ActionResult Index()
		{
			
			return View();
		}
		public ActionResult Deposit(long? depositAccount, decimal? amount, String result, int? idCurrency)
		{
			this.ViewData["idCurrency"] = new SelectList(db.Currencies, "idCurrency", "name");
			transcation(TransactionType.Deposit, depositAccount, null, amount, idCurrency);

			//if(depositAccount != null && amount != null)
			//{
			//	//check if account exists
			//	Context db = new Context();
				
			//	var account = (from acc in db.BankAccounts
			//					where acc.idAccountNumber == depositAccount
			//					select acc);
				
			//	if (account.Any())
			//	{
			//		decimal amountNotNull = (decimal)amount;
			//		account.First().deposit(db,amountNotNull);

			//		//ViewBag.Message("Succesful!");
			//		return View();
			//	}
			//}
			//ViewBag.Message("Failded!");
			return View();
		}
		public ActionResult Withdraw(long? withdrawAccount, decimal? amount, String result, int? idCurrency)
		{
			this.ViewData["idCurrency"] = new SelectList(db.Currencies, "idCurrency", "name");
			transcation(TransactionType.Withdraw, withdrawAccount, null, amount, idCurrency);
			//if (withdrawAccount != null && amount != null)
			//{
			//	//check if account exists
			//	Context db = new Context();

			//	var account = (from acc in db.BankAccounts
			//				   where acc.idAccountNumber == withdrawAccount
			//				   select acc);

			//	if (account.Any())
			//	{
			//		decimal amountNotNull = (decimal)amount;
					
			//		account.First().withdraw(db, amountNotNull);

			//		//ViewBag.Message("Succesful!");
			//		return View();
			//	}
			//}
			//ViewBag.Message("Failded!");
			return View();
		}
		public ActionResult Transfer(long? fromAccount, long? toAccount, decimal? amount, String result, int? idCurrency)
		{
			this.ViewData["idCurrency"] = new SelectList(db.Currencies, "idCurrency", "name");
			transcation(TransactionType.Transfer, fromAccount, toAccount, amount, idCurrency);

			//if (fromAccount != null && toAccount !=null && amount != null)
			//{
			//	//check if account exists
			//	Context db = new Context();

			//	var account = (from acc in db.BankAccounts
			//				   where acc.idAccountNumber == fromAccount
			//				   select acc);

			//	var accountTo = 
			//	if (account.Any())
			//	{
			//		double amountNotNull = (double)amount;

			//		account.First().withdraw(db, amountNotNull);

			//		//ViewBag.Message("Succesful!");
			//		return View();
			//	}
			//}
			//ViewBag.Message("Failded!");
			return View();
		}
		private void transcation(TransactionType tt,long? account1,long? account2,decimal? amount,int? _currency )
		{
			if (account1 != null && amount != null && _currency != null)
			{
				
				var account = (from acc in db.BankAccounts
								where acc.idAccountNumber == account1
								select acc);
				var currency =(from curr in db.Currencies
									where curr.idCurrency == _currency
									select curr);

				if (account.Any())
				{

					decimal amountNotNull = (decimal)amount;
					var transation = db.Database.BeginTransaction();
					try {
						if (TransactionType.Deposit.Equals(tt))
						{
							account.First().deposit(db, amountNotNull,tt,currency.First());
						}
						else if(TransactionType.Withdraw.Equals(tt))
						{
							account.First().withdraw(db, amountNotNull, tt, currency.First());
						}
						else if (TransactionType.Transfer.Equals(tt) && account2!= null)
						{
							var accountTo = (from acc in db.BankAccounts
										   where acc.idAccountNumber == account2
										   select acc);
							
							account.First().withdraw(db, amountNotNull, tt,currency.First());
							accountTo.First().deposit(db, amountNotNull, tt,currency.First());
						}
						transation.Commit();
					}
					catch (Exception) 
					{
						transation.Rollback();
					}
					
					//ViewBag.Message("Succesful!");
				}
								
			}


		}

	}
}