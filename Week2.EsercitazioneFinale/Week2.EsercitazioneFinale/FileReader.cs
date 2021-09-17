using Library;
using Library.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale
{
    public class FileReader
    {
        public static List<Good> ReadFile(string path)
        {
            List<Good> goods = new List<Good>();
            Good readedGood = null;

            using (StreamReader reader = File.OpenText(path))
            {
                string line;
                line = reader.ReadLine();

                Console.WriteLine("Loading file...");
                while ((line = reader.ReadLine()) != null)
                {
                    LoadedGood loadedGood = LoadedGood.ParseLineFromFile(line);
                    if (!string.IsNullOrEmpty(loadedGood.Producer))
                    {
                        readedGood = new ElectronicGood(loadedGood.Code, loadedGood.Description, loadedGood.Price,
                                                        loadedGood.ReceiptDate, loadedGood.StockQuantity, loadedGood.Producer);
                        goods.Add(readedGood);
                    }
                    if (loadedGood.Type.HasValue && loadedGood.AlcoholContent.HasValue)
                    {
                        readedGood = new SpiritDrinkGood(loadedGood.Code, loadedGood.Description, loadedGood.Price,
                                                        loadedGood.ReceiptDate, loadedGood.StockQuantity, (TypeOfDrink)loadedGood.Type, (double)loadedGood.AlcoholContent);
                        goods.Add(readedGood);
                    }
                    if (loadedGood.ExpiryDate.HasValue && loadedGood.Storage.HasValue)
                    {
                        readedGood = new PerishableGood(loadedGood.Code, loadedGood.Description, loadedGood.Price,
                                                        loadedGood.ReceiptDate, loadedGood.StockQuantity, (DateTime)loadedGood.ExpiryDate, (StorageCondition)loadedGood.Storage);
                        goods.Add(readedGood);
                    }
                }
            }

            Console.WriteLine("Loading Completed");
            return goods;
        }
    }
}
