using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities
{
    public class LoadedGood : Good
    {
        public string Producer { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public StorageCondition? Storage { get; set; }
        public TypeOfDrink? Type { get; set; }
        public double? AlcoholContent { get; set; }


        public LoadedGood(string code, string desc, decimal price, DateTime recDate, int quantity, string producer, DateTime? expiry, StorageCondition? storage, TypeOfDrink? type, double? alcohol) : base(code, desc, price, recDate, quantity)
        {
            Producer = producer;
            ExpiryDate = expiry;
            Storage = storage;
            Type = type;
            AlcoholContent = alcohol;
        }

        public static LoadedGood ParseLineFromFile(string line)
        {
            string[] details = line.Split(';');
            LoadedGood goodLoaded = null;

            if (details.Length != 11)
            {
                Console.WriteLine("Error: it is not possible to create the Good. Review inserted data in the file.");
            }
            else
            {
                string code = details[0];
                string desc = details[1];
                decimal.TryParse(details[2], out decimal price);
                DateTime.TryParse(details[3], out DateTime receipt);
                int.TryParse(details[4], out int quantity);

                if (!details[5].Equals("-"))
                {
                    string productor = details[5];
                    goodLoaded = new LoadedGood(code, desc, price, receipt, quantity, productor,null,null,null,null);
                }
                if(!details[6].Equals("-") && !details[7].Equals("-"))
                {
                    Enum.TryParse<TypeOfDrink>(details[6].ToUpper(), out TypeOfDrink type);
                    double.TryParse(details[7], out double alcohol);
                    goodLoaded = new LoadedGood(code, desc, price, receipt, quantity, null, null, null, type, alcohol);
                }
                if (!details[8].Equals("-") && !details[9].Equals("-"))
                {
                    DateTime.TryParse(details[8], out DateTime expiry);
                    Enum.TryParse<StorageCondition>(details[9].ToUpper(), out StorageCondition storage);
                    goodLoaded = new LoadedGood(code, desc, price, receipt, quantity, null, expiry, storage, null, null);
                }
            }

            return goodLoaded;
        }
    }
}
