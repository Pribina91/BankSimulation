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
    public class BankAccountController : Controller
    {
        private Context db = new Context();

        // GET: /BankAccount/
        public ActionResult Index()
        {
            var bankaccounts = db.BankAccounts.Include(b => b.currency);
            return View(bankaccounts.ToList());
        }

        // GET: /BankAccount/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        // GET: /BankAccount/Create
        public ActionResult Create()
        {
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name");
            return View();
        }

        // POST: /BankAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idAccountNumber,idCurrency,balance")] BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", bankaccount.idCurrency);
            return View(bankaccount);
        }

        // GET: /BankAccount/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", bankaccount.idCurrency);
            return View(bankaccount);
        }

        // POST: /BankAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idAccountNumber,idCurrency,balance")] BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCurrency = new SelectList(db.Currencies, "idCurrency", "name", bankaccount.idCurrency);
            return View(bankaccount);
        }

        // GET: /BankAccount/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        // POST: /BankAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankaccount);
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
