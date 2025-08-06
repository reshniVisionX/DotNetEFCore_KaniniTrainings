using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class Seven_ElevenShop
    {
        List<Beverages> bl = new List<Beverages>();
        public void Seven11()
        {
            bl.Add(new Beverages(1, "Coca Cola", 50, 1000));
            bl.Add(new Beverages(2, "Pepsi", 45, 1000));
            bl.Add(new Beverages(3, "Sting", 60, 700));
            bl.Add(new Beverages(4, "Mountain Dew", 100, 800));
            bl.Add(new Beverages(5, "Red Bull", 90, 500));
            bl.Add(new Beverages(6, "Miranda", 35, 500));

            int choice = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("***Seven-Eleven welcomes u... Select below****");
                Console.WriteLine("1. Filter by cost");
                Console.WriteLine("2. Filter by first letter");
                Console.WriteLine("3. Filter by quantity");
                Console.WriteLine("4. Exit....");
                choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            FilterByCost();
                            break;
                        case 2:
                            FilterByLetter();
                            break;
                        case 3:
                            FilterByQuantity();
                            break;
                        case 4:
                            Console.WriteLine("Exiting...Thankyou");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Entry");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occured " + e.Message);
            }
            } while (true) ;
           
        }
        public void FilterByCost()
        {
            Console.WriteLine("Enter the price to see the beverages : ");
            double price = double.Parse(Console.ReadLine());
            IEnumerable<Beverages> list = from b in bl
                                          where b.cost >= price
                                          orderby b.cost ascending
                                          select b;

            foreach (Beverages b in list)
            {
                Console.WriteLine($"{b.name} -> Rs.{b.cost}, {b.quantity} ml");
            }
        }
        public void FilterByLetter()
        {
            Console.WriteLine("Enter the first letter to see the beverages : ");
            char ch  = char.Parse(Console.ReadLine());

            IEnumerable<Beverages>  list = from b in bl
                                           where b.name.StartsWith(ch.ToString(), StringComparison.OrdinalIgnoreCase)
                                           select b;

            foreach (Beverages b in list)
            {
                Console.WriteLine($"{b.name} -> Rs.{b.cost}, {b.quantity} ml");
            }
        }
        public void FilterByQuantity()
        {
            Console.WriteLine("Enter the quantity to see the beverages : ");
            double quant = double.Parse(Console.ReadLine());

            IEnumerable<Beverages> list = from b in bl
                                          where b.quantity >= quant
                                          orderby b.quantity ascending
                                          select b;

            foreach (Beverages b in list)
            {
                Console.WriteLine($"{b.name} -> Rs.{b.cost}, {b.quantity} ml");
            }
        }

    }
    class Beverages
    {
        public int id { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public double quantity { get; set; }

        public Beverages(int id, string name, double cost, double quantity)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.quantity = quantity;
        }
    }

}
