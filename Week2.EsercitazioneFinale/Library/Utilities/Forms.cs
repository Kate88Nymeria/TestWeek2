using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities
{
    public class Forms
    {
        public static Good InsertGood()
        {
            bool continueExec = true;
            Good goodToAdd = null;

            do
            {
                Console.WriteLine("Which kind of Good would you like to insert?");

                Console.WriteLine();
                Console.WriteLine("1 - Electronic Good");
                Console.WriteLine("2 - Perishable Good");
                Console.WriteLine("3 - Spirit Drink Good");
                Console.WriteLine("4 - Undo");
                Console.WriteLine();

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        goodToAdd = InsertElectronicGood();
                        continueExec = false;
                        break;
                    case 2:
                        goodToAdd = InsertPerishableGood();
                        continueExec = false;
                        break;
                    case 3:
                        goodToAdd = InsertSpiritDrinkGood();
                        continueExec = false;
                        break;
                    case 4:
                        continueExec = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid option inserted.");
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                }
            } while (continueExec);

            if(goodToAdd != null)
            {
                Console.WriteLine();
                Console.WriteLine("Good correctly inserted");
            }

            return goodToAdd;
        }

        public static Good RemoveGood(Warehouse w)
        {
            w.ViewGoodList();
            Good goodToRemove = null;

            if (w.StockGoods.Count == 0)
            {
                Console.WriteLine("It is not possible to remove anything.");
            }
            else
            {
                string choice;

                Console.WriteLine();
                Console.WriteLine("Insert the Code of the good you want to remove");

                choice = Helpers.CheckNullString();

                goodToRemove = w.SearchGood(choice);

                if(goodToRemove != null)
                {
                    Console.WriteLine("Good correctly removed");
                }
                else
                {
                    Console.WriteLine("Good not found");
                }
            }
            return goodToRemove;
        }

        #region insert methods

        public static ElectronicGood InsertElectronicGood()
        {
            Console.WriteLine("Insert Article Code");
            string code = Helpers.CheckNullString();
            
            Console.WriteLine();
            Console.WriteLine("Insert Article Description");
            string desc = Helpers.CheckNullString();

            Console.WriteLine();
            Console.WriteLine("Insert Article Price");
            decimal price = Helpers.CheckDecimal();

            DateTime receipt = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Insert Article Quantity");
            int quantity = Helpers.CheckIntGreaterThanZero();

            Console.WriteLine();
            Console.WriteLine("Insert Article Producer");
            string producer = Helpers.CheckNullString();

            ElectronicGood good = new ElectronicGood(code,desc,price,receipt,quantity,producer);

            return good;
        }

        public static PerishableGood InsertPerishableGood()
        {
            Console.WriteLine("Insert Article Code");
            string code = Helpers.CheckNullString();

            Console.WriteLine();
            Console.WriteLine("Insert Article Description");
            string desc = Helpers.CheckNullString();

            Console.WriteLine();
            Console.WriteLine("Insert Article Price");
            decimal price = Helpers.CheckDecimal();

            DateTime receipt = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Insert Article Quantity");
            int quantity = Helpers.CheckIntGreaterThanZero();

            Console.WriteLine();
            Console.WriteLine("Insert Article Expiry Date");
            DateTime expiry = Helpers.CheckDateTime();

            Console.WriteLine();
            Console.WriteLine("Insert Article Storage Condition");
            StorageCondition storage = StorageCondition.FREEZER;

            bool continueExec = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Freezer");
                Console.WriteLine("2 - Fridge");
                Console.WriteLine("3 - Shelf");
                Console.WriteLine();

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        storage = StorageCondition.FREEZER;
                        continueExec = false;
                        break;
                    case 2:
                        storage = StorageCondition.FRIDGE;
                        continueExec = false;
                        break;
                    case 3:
                        storage = StorageCondition.SHELF;
                        continueExec = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid option inserted.");
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                }
            } while (continueExec);
            

            PerishableGood good = new PerishableGood(code, desc, price, receipt, quantity, expiry, storage);

            return good;
        }

        public static SpiritDrinkGood InsertSpiritDrinkGood()
        {
            Console.WriteLine("Insert Article Code");
            string code = Helpers.CheckNullString();

            Console.WriteLine();
            Console.WriteLine("Insert Article Description");
            string desc = Helpers.CheckNullString();

            Console.WriteLine();
            Console.WriteLine("Insert Article Price");
            decimal price = Helpers.CheckDecimal();

            DateTime receipt = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Insert Article Quantity");
            int quantity = Helpers.CheckIntGreaterThanZero();

            Console.WriteLine();
            Console.WriteLine("Insert Type of Drink");
            TypeOfDrink type = TypeOfDrink.WHISKY;

            bool continueExec = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Whisky");
                Console.WriteLine("2 - Wodka");
                Console.WriteLine("3 - Grappa");
                Console.WriteLine("4 - Gin");
                Console.WriteLine("5 - Other");
                Console.WriteLine();

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        type = TypeOfDrink.WHISKY;
                        continueExec = false;
                        break;
                    case 2:
                        type = TypeOfDrink.WODKA;
                        continueExec = false;
                        break;
                    case 3:
                        type = TypeOfDrink.GRAPPA;
                        continueExec = false;
                        break;
                    case 4:
                        type = TypeOfDrink.GIN;
                        continueExec = false;
                        break;
                    case 5:
                        type = TypeOfDrink.OTHER;
                        continueExec = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid option inserted.");
                        Helpers.ContinueExecution();
                        Console.Clear();
                        break;
                }
            } while (continueExec);

            Console.WriteLine();
            Console.WriteLine("Insert Alcohol Content");
            double alcohol = Helpers.CheckDouble();

            SpiritDrinkGood good = new SpiritDrinkGood(code, desc, price, receipt, quantity, type, alcohol);

            return good;
        }

        #endregion
    }
}
