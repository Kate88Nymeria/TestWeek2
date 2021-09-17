using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SpiritDrinkGood : Good
    {
        public TypeOfDrink Type { get; set; }
        public double AlcoholContent { get; set; }

        #region ctor

        public SpiritDrinkGood(string code, string desc, decimal price, DateTime recDate, int quantity, TypeOfDrink type, double alc) : base(code, desc, price, recDate, quantity)
        {
            Type = type;
            AlcoholContent = alc;
        }

        #endregion

        public override string ToString()
        {
            return base.ToString() + $"{'-', 20}{this.Type, 15}{this.AlcoholContent,18}{'-',17}{'-', 20}";
        }
    }
}
