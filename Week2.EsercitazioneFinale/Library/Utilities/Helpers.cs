using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities
{
    public class Helpers
    {
        public static int CheckInt()
        {
            bool isInt = false;
            int number = 0;

            do
            {
                isInt = int.TryParse(Console.ReadLine(), out number);

                if (!isInt)
                {
                    Console.WriteLine("Error: please insert an int number. Try Again:");
                }
            } while (!isInt);

            return number;
        }

        public static decimal CheckDecimal()
        {
            bool isDecimal = false;
            decimal number = 0;

            do
            {
                isDecimal = decimal.TryParse(Console.ReadLine(), out number);

                if (!isDecimal || number < 0)
                {
                    Console.WriteLine("Error: please insert a valid number greater than zero. Try Again:");
                }
            } while (!isDecimal || number < 0);

            return number;
        }

        public static void ContinueExecution()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        public static string CheckNullString()
        {
            string text = "";

            do
            {
                text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Error: you cannot insert empty values. Try Again:");
                }
            } while (string.IsNullOrEmpty(text));

            return text;
        }

        public static int CheckIntGreaterThanZero()
        {
            int number = 0;

            do
            {
                number = CheckInt();

                if (number <= 0)
                {
                    Console.WriteLine("Error: please insert a number greater than zero. Try Again:");
                }
            } while (number <= 0);

            return number;
        }

        public static DateTime CheckDateTime()
        {
            bool isDateTime = false;
            DateTime date;

            do
            {
                isDateTime = DateTime.TryParse(Console.ReadLine(), out date);

                if (!isDateTime || date < DateTime.Now)
                {
                    Console.WriteLine("Error: please insert a valid date greater than today. Try Again:");
                }
            } while (!isDateTime || date < DateTime.Now);

            return date;
        }

        public static double CheckDouble()
        {
            bool isDouble = false;
            double number = 0;

            do
            {
                isDouble = double.TryParse(Console.ReadLine(), out number);

                if (!isDouble || number < 0)
                {
                    Console.WriteLine("Error: please insert a valid number greater than zero. Try Again:");
                }
            } while (!isDouble || number < 0);

            return number;
        }
    }
}
