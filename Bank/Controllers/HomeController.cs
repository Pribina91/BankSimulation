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
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Deposit(long? depositAccount, decimal? amount, String result)
		{
			if(depositAccount != null && amount != null)
			{
				//check if account exists
				Context db = new Context();
				
				var account = (from acc in db.BankAccounts
								where acc.idAccountNumber == depositAccount
								select acc);
				
				if (account.Any())
				{
					decimal amountNotNull = (decimal)amount;
					account.First().deposit(db,amountNotNull);

					//ViewBag.Message("Succesful!");
					return View();
				}
			}
			//ViewBag.Message("Failded!");
			return View();
		}
		public ActionResult Withdraw(long? withdrawAccount, decimal? amount, String result)
		{
			if (withdrawAccount != null && amount != null)
			{
				//check if account exists
				Context db = new Context();

				var account = (from acc in db.BankAccounts
							   where acc.idAccountNumber == withdrawAccount
							   select acc);

				if (account.Any())
				{
					decimal amountNotNull = (decimal)amount;
					
					account.First().withdraw(db, amountNotNull);

					//ViewBag.Message("Succesful!");
					return View();
				}
			}
			//ViewBag.Message("Failded!");
			return View();
		}
		public ActionResult Transfer(long? fromAccount, long? toAccount, decimal? amount, String result)
		{
			if (fromAccount != null && toAccount != null && amount != null)
			{
				Withdraw(fromAccount, amount, result);
				Deposit(toAccount, amount, result);

			}

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

	}
}