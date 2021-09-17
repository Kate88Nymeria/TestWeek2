using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Good
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int StockQuantity { get; set; }


        #region ctor

        public Good(string code, string desc, decimal price, DateTime recDate, int quantity)
        {
            Code = code;
            Description = desc;
            Price = price;
            ReceiptDate = recDate;
            StockQuantity = quantity;
        }

        #endregion

        public override string ToString()
        {
            string line = $"{this.Code,-13}{this.Description, -20}{this.Price, -10}{this.ReceiptDate.ToShortDateString(),-17}{this.StockQuantity, -15}";

            return line;
        }
    }
}
