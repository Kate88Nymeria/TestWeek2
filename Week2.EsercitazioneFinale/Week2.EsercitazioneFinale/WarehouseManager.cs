using Library;
using Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale
{
    public class WarehouseManager
    {
        public static Warehouse myWarehouse = new Warehouse(Guid.NewGuid(),
                                "Via Roma 124, Milano - Italy", new DateTime(2021, 08, 13));

        static string path = @"C:\Users\katia.caracciolo\Desktop\Projects\Week2\Week2.EsercitazioneFinale\goods.txt";
        public static void ManageWarehouse()
        {
            bool continueExec = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - View Your Warehouse's State");
                Console.WriteLine("2 - Add a Good to your Warehouse");
                Console.WriteLine("3 - Remove a Good from your Warehouse");
                Console.WriteLine("4 - Read Goods from file");
                Console.WriteLine("5 - Exit");
                Console.WriteLine();

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        myWarehouse.StockList();
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Good goodToAdd = Forms.InsertGood();
                        myWarehouse = myWarehouse + goodToAdd;
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Good goodToRemove = Forms.RemoveGood(myWarehouse);
                        myWarehouse = myWarehouse - goodToRemove;
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        myWarehouse.StockGoods = LoadFile();
                        //FileReader fr = new FileReader();
                        //myWarehouse.StockGoods = fr.ReadFile(path);
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                    case 5:
                        continueExec = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid option inserted.");
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                }

            }while(continueExec);
        }

        public static List<Good> LoadFile()
        {
            FileReader fr = new FileReader();
            List<Good> goods = fr.ReadFile(path);

            fr.StartReading += Fr_StartReading;
            fr.ProgressReading += Fr_ProgressReading;
            fr.CompleteReading += Fr_CompleteReading;

            try
            {
                fr.ReadFile(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading data. Message: {ex.Message}");
            }

            return goods;
        }

        #region EventHandler

        private static void Fr_CompleteReading(object sender, LoadingEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Loading Completed");
        }

        private static void Fr_ProgressReading(object sender, LoadingEventArgs e)
        {
            Console.WriteLine("Loading in Progress...");
        }
        
        private static void Fr_StartReading(string file)
        {
            Console.WriteLine("Starting Loading...");
            Console.WriteLine();
        }

        #endregion
    }
}
