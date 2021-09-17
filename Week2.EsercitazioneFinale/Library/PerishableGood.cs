using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PerishableGood : Good
    {
        public DateTime ExpiryDate { get; set; }
        public StorageCondition Storage { get; set; }

        #region ctor

        public PerishableGood(string code, string desc, decimal price, DateTime recDate, int quantity, DateTime expiry, StorageCondition storage) : base(code, desc, price, recDate, quantity)
        {
            ExpiryDate = expiry;
            Storage = storage;
        }

        #endregion

        public override string ToString()
        {
            return base.ToString() + $"{'-', 20}{'-', 15}{'-',18}{this.ExpiryDate.ToShortDateString(),17}{this.Storage, 20}";
        }
    }
}
