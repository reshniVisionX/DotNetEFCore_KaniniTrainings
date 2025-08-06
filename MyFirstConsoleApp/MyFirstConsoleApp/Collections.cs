using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace MyFirstConsoleApp
{
    internal class Collections
    {
        Dictionary<string, DateTime> ftime = new Dictionary<string, DateTime>()
        {
         { "A11", DateTime.Today.AddHours(18).AddMinutes(30) },
         { "A12", DateTime.Today.AddHours(18) },
         { "A13", DateTime.Today.AddHours(8) }, 
         { "A14", DateTime.Today.AddHours(22) }
        };

        public void FlightTime()
        {
            Console.WriteLine("Enter the flight number :");
            String no = Console.ReadLine();
            if (!ftime.ContainsKey(no))
            {
               Console.WriteLine("Invalid Flight Number");
                return;
            }
            DateTime departureTime = ftime[no];
            DateTime currentTime = DateTime.Now;

            if (currentTime >= departureTime)
            {
                Console.WriteLine( "Flight Already Left");
            }
            else
            {
                TimeSpan timeleft = departureTime - currentTime;
                Console.WriteLine($"Time To Flight {timeleft}");
            }

        }
    }
    public class Products
    {
        private String product_name;
        private String serial_no;
        private DateTime purchase_date;
        private double cost;

        public Products() { }
       public Products(string product_name, string serial_no, DateTime purchase_date, double cost)
        {
            this.product_name = product_name;
            this.serial_no = serial_no;
            this.purchase_date = purchase_date;
            this.cost = cost;
        }
        List<Products> al = new List<Products>();
        public  void ProductMain()
        {
           
            int choice = 0;
            do
            {
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProducts();
                        break;
                    case 2:
                        DisplayProducts();
                        break;
                    case 3:
                        Console.WriteLine(" Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (true);
            
        }
        public void AddProducts()
        {

            Console.WriteLine("Enter the product name : ");
            product_name = Console.ReadLine();
            Console.WriteLine("Enter the serial number : ");
            serial_no = Console.ReadLine();
            Console.WriteLine("Enter the purchase date (Format-2025-01-01) : ");
            purchase_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the cost :");
            cost = double.Parse(Console.ReadLine());

            al.Add(new Products(product_name, serial_no, purchase_date, cost));
        }
        public void DisplayProducts()
        {
            Console.WriteLine("Product List ...");
            foreach(Products p in al)
            {
                Console.WriteLine("Name: "+p.product_name+" No: "+p.serial_no+" Cost: "+p.cost+" Date: "+p.purchase_date);
            }
            Console.WriteLine();
        }
    }

    class BallsBowled
    {
        private int balls;
        private int overs;

        public BallsBowled() { }
        public BallsBowled(int balls, int overs)
        {
            this.balls = balls;
            this.overs = overs;
        }
        List<int> list = new List<int>();
        public void BallsProgram()
        {
            Console.WriteLine("Enter the number of overs ");
            balls = int.Parse(Console.ReadLine());
            AddOversDetails(balls);
        }

        public void AddOversDetails(int balls)
        {
            list.Add(balls * 6);
            Console.WriteLine("No of balls bowled : " + (balls * 6));
        }
    }

    class Members
    {
        List<String> gold = new List<string>();
        List<String> silver = new List<string>();
        List<String> platinum = new List<string>();

        public void MembersCall()
        {
            do
            {
                Console.WriteLine("Enter the grp in which you need to add members: ");
                Console.WriteLine("1. Gold");
                Console.WriteLine("2. Silver");
                Console.WriteLine("3. Platinum");
                Console.WriteLine("4. Exit");
                
                int choice = int.Parse(Console.ReadLine());
                if(choice == 4)
                {

                    Console.WriteLine("Invalid Entry...Exiting...");
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter the members name: ");
                String name = Console.ReadLine();
                if (choice == 1)
                {
                    gold.Add(name);
                    Display(gold);
                }
                else if (choice == 2)
                {
                    silver.Add(name);
                    Display(silver);
                }
                else if (choice == 3)
                {
                    platinum.Add(name);
                    Display(platinum);
                }
              
            } while (true);
            
        }
        public void Display(List<String> gold)
        {
            Console.WriteLine("The members of this group are : ");
            foreach (String s in gold) {
                Console.WriteLine(s);
            }
        }
    }
}
