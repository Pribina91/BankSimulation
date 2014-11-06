using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSimulation.Models
{
	public class Currency
	{
		public Currency()
		{

		}
		[Key]
		public int idCurrency { get; set; }
		double _rate;

		public double rate
		{
			get { return this._rate; }
			set { this._rate = Math.Round(value, 3); }
		}
		public int units { set; get; }

	}
}
