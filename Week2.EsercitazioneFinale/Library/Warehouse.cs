using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public decimal TotStockGoods { get {return CalculateTotStockGoods(); } }
        public DateTime LastMovement { get; set; }
        public List<Good> StockGoods { get; set; }


        #region ctor

        public Warehouse(Guid id, string address, DateTime lastMov)
        {
            Id = id;
            Address = address;
            LastMovement = lastMov;
            StockGoods = new List<Good>();
        }

        #endregion

        #region operator overloading

        public static Warehouse operator +(Warehouse w, Good good)
        {
            w.StockGoods.Add(good);
            w.LastMovement = DateTime.Now;
            //w.TotStockGoods += good.Price;
            return w;
        }

        public static Warehouse operator -(Warehouse w, Good good)
        {
            w.StockGoods.Remove(good);
            w.LastMovement = DateTime.Now;
            //w.TotStockGoods -= good.Price;
            return w;
        }

        #endregion

        public void StockList()
        {
            Console.WriteLine(this);

            ViewGoodList();
        }

        public void ViewGoodList()
        {
            Console.WriteLine("{0,-13}{1, -20}{2, -10}{3,-17}{4, -15}{5, 20}{6, 15}{7,18}{8,17}{9, 20}",
               "Art. Code", "Description", "Price", "Receipt Date", "Stock Quantity",
               "Producer", "Type of Drink", "Alcohol Content", "Expiry Date", "Storage Condition"
               );

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 165));

            if (StockGoods.Count == 0)
            {
                sb.AppendLine("No Goods inserted");
            }
            else
            {
                foreach (Good g in StockGoods)
                {
                    {
                        sb.AppendLine(g.ToString() + "\n");
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public decimal CalculateTotStockGoods()
        {
            decimal tot = 0;

            foreach(Good g in StockGoods)
            {
                tot += g.Price;
            }

            return tot;
        }

        public Good SearchGood(string code)
        {
            if(code != null)
            {
                return this.StockGoods.FirstOrDefault(g => g.Code == code);
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nID: {Id}\t-\tAddress: {Address}");
            sb.AppendLine(new string('-', 165));
            sb.AppendLine($"Total Stock Goods: {TotStockGoods} euro\t-\tLast Movement: {LastMovement.ToShortDateString()}");
            sb.AppendLine(new string('-', 165) + "\n");

            return sb.ToString() ;
        }
    }
}
