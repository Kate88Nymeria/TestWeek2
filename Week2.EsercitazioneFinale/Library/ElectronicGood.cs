using Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ElectronicGood : Good
    {
        public string Producer { get; set; }

        #region ctor
        public ElectronicGood(string code, string desc, decimal price, DateTime recDate, int quantity, string prod) : base(code, desc, price, recDate, quantity)
        {
            if (string.IsNullOrEmpty(prod))
            {
                throw new GoodException("Invalid Producer");
            }
            Producer = prod;
        }
        #endregion

        public override string ToString()
        {
            return base.ToString() + $"{this.Producer, 20}{'-', 15}{'-',18}{'-',17}{'-', 20}";
        }
    }
}
