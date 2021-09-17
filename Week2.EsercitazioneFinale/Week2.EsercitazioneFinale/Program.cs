using System;
using Library.Utilities;

namespace Week2.EsercitazioneFinale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== WELCOME TO WAREHOUSE MANAGER ======");

            WarehouseManager.ManageWarehouse();

            Console.WriteLine();
            Console.WriteLine("====== Bye Bye ======");

            Helpers.ContinueExecution();
        }
    }
}
