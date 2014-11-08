using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankSimulation.Models;

namespace Bank.Controllers
{
    public class TransactionController : Controller
    {
        private Context db = new Context();

        // GET: /Transaction/
		public ActionResult Index(string transactionType,int? minAmount, int? maxAmount) //TODO filtering min max
        {
            var transactions = db.Transactions.Include(t => t.accountNumber).Include(t => t.currency);

			if (!String.IsNullOrEmpty(transactionType))
			{
				transactions = transactions.Where(s => s.type.Equals(transactionType));
			}

			if(minAmount != null)
			{
				transactions = transactions.Where(s => s.amount >= minAmount);
			}

			if (maxAmount != null)
			{
				transactions = transactions.Where(s => s.amount <= maxAmount);
			}

            return View(transactions.ToList());
        }

        // GET: /Transaction/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: /Transaction/Create
        public ActionResult Create()
        {
            ViewBag.idAccountNumber = new SelectList(db.BankAccounts, "idAccountNumber", "idAccountNumber");
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name");
            return View();
        }

        // POST: /Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idTransation,idAccountNumber,idCurrency,amount,timestamp")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAccountNumber = new SelectList(db.BankAccounts, "idAccountNumber", "idAccountNumber", transaction.idAccountNumber);
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", transaction.idCurrency);
            return View(transaction);
        }

        // GET: /Transaction/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAccountNumber = new SelectList(db.BankAccounts, "idAccountNumber", "idAccountNumber", transaction.idAccountNumber);
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", transaction.idCurrency);
            return View(transaction);
        }

        // POST: /Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idTransation,idAccountNumber,idCurrency,amount,timestamp")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAccountNumber = new SelectList(db.BankAccounts, "idAccountNumber", "idAccountNumber", transaction.idAccountNumber);
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", transaction.idCurrency);
            return View(transaction);
        }

        // GET: /Transaction/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: /Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
