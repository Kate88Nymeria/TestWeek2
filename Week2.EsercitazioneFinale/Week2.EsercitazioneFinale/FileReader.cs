using Library;
using Library.Exceptions;
using Library.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale
{
    public delegate void ReaderStartProcess(string file);
    public class FileReader
    {
        public event ReaderStartProcess StartReading;
        public event EventHandler<LoadingEventArgs> ProgressReading;
        public event EventHandler<LoadingEventArgs> CompleteReading;

        public List<Good> ReadFile(string path)
        {
            List<Good> goods = new List<Good>();
            Good readedGood = null;

            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string line;
                    line = reader.ReadLine();

                    if (StartReading != null)
                    {
                        StartReading(path);
                    }

                    Thread.Sleep(1000);

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

                        if (ProgressReading != null)
                        {
                            ProgressReading(this, new LoadingEventArgs());
                        }
                        Thread.Sleep(200);
                    }

                    if (CompleteReading != null)
                    {
                        CompleteReading(this, new LoadingEventArgs());
                    }
                }
            }
            catch (IOException ioe)
            {
                throw new WarehouseException($"Error processing file {path}");
            }
            catch (Exception ex)
            {
                throw new WarehouseException($"Generic error with file {path}");
            }
            

            return goods;
        }
    }
}
