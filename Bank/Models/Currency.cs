using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSimulation.Models
{
	public class Currency
	{
		public Currency() { }
		public Currency(String _name,decimal _rate,int _units)
		{
			this.name = _name;
			this.rate = _rate;
			this.units = _units;
		}
		[Key]
		public int idCurrency { get; set; }
		[Display(Name = "Currency Name")]
		public String name { get; set; }
		decimal _rate;
		public decimal rate
		{
			get { return this._rate; }
			set { this._rate =value; }
		}
		public int units { set; get; }

		public virtual IEnumerable<BankAccount> accounts { get; set; }
		public virtual IEnumerable<Transaction> transactions { get; set; }
	}
}
