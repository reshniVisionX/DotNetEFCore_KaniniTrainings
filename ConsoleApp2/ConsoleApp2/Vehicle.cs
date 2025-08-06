using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp2
{
    internal class Vehicle
    {
        private String make;
        private String model;
        private int year;

        public Vehicle(String make, String model, int year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine("Making : " + make);
            Console.WriteLine("Model : " + model);
            Console.WriteLine("Year : " + year);
        }

    }
    class Car : Vehicle
    {
        public Car(string make, string model, int year) : base(make, model, year)
        {

        }
        public override void GetInfo()
        {
            Console.WriteLine(" Type is car ");
            base.GetInfo();

        }
    }
    class Motorcycle : Vehicle
    {

        public Motorcycle(string make, string model, int year) : base(make, model, year)
        {

        }
        public override void GetInfo()
        {
            Console.WriteLine("Type is motorcycle");
            base.GetInfo();

        }
    }

    class Student
    {
        private string name;
        private int age;
        private String grade;

        public Student(string name, int age, String grade)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }
        public void PrintData()
        {
            Console.WriteLine($"Student Name : {name} , Age : {age} , Grade : {grade}");
        }
    }


    struct Product
    {
        public void Main()
        {
            Console.WriteLine("Enter the number of products to store: ");
            int n = int.Parse(Console.ReadLine());
            string[][] arr = new string[n][];
            int productCount = 0;

            while (true)
            {
                Console.WriteLine("\n1. Add Products");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Update Products");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        productCount = AddProduct(arr, productCount, n);
                        break;
                    case 2:
                        DisplayProducts(arr, productCount);
                        break;
                    case 3:
                        UpdateProductByName(arr, productCount);
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static int AddProduct(string[][] products, int productCount, int maxSize)
        {
            if (productCount < maxSize)
            {
                products[productCount] = new string[3];

                Console.Write("Enter the product name: ");
                products[productCount][0] = Console.ReadLine();

                Console.Write("Enter the price: ");
                products[productCount][1] = Console.ReadLine();

                Console.Write("Enter the quantity: ");
                products[productCount][2] = Console.ReadLine();

                Console.WriteLine("Product added successfully!");
                return productCount + 1;
            }
            else
            {
                Console.WriteLine("The storage is full. Cannot add more products.");
                return productCount;
            }
        }

        public static void DisplayProducts(string[][] products, int productCount)
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products to display.");
                return;
            }

            Console.WriteLine("\n--------------Product List---------------");

            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($" {products[i][0]}\t {products[i][1]}\t {products[i][2]}\t  ");
            }
            Console.WriteLine("------------------------------------------------");
        }

        public static void UpdateProductByName(string[][] products, int productCount)
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products to update.");
                return;
            }

            Console.Write("Enter the name of the product to update: ");
            string UpdateName = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < productCount; i++)
            {
                if (products[i][0].Equals(UpdateName, StringComparison.OrdinalIgnoreCase))
                {

                    Console.Write("Enter new price: ");
                    string newPrice = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newPrice))
                    {
                        products[i][1] = newPrice;
                    }

                    Console.Write("Enter new quantity: ");
                    string newQty = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newQty))
                    {
                        products[i][2] = newQty;
                    }

                    Console.WriteLine("Product updated successfully!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

    class Account
    {
        private String acc_type;
        private decimal balance;
        private string name;

        public Account(String acc_type,decimal balance,string name)
        {
            this.acc_type = acc_type;
            this.balance = balance;
            this.name = name;
        }

        public void DepositFunds(decimal amt)
        {
            if (amt < 0)
            {
                Console.WriteLine("Invalid deposit entry");
                return;
            }
            balance += amt;
            DisplayData();
        }

        public void WithdrawFunds(decimal amt)
        {
            if (amt < 0)
            {
                Console.WriteLine("Invalid withdraw entry");
                return;
            }
            else if (balance >= amt)
            {
                balance -= amt;
            }
            else
            {
                Console.WriteLine("Insufficient funds to withdraw");
            }
            DisplayData();
        }
        public void DisplayData()
        {
            Console.WriteLine("The Account holder name: " + this.name);
            Console.WriteLine("The balance: " + this.balance);
            Console.WriteLine("The Account type: " + this.acc_type);
        }

    }

    class Game
    {
        private String name;
        private int player;

        public Game(String name,int player)
        {
            this.name = name;
            this.player = player;
        }

        public override string ToString()
        {
            return "The game "+name+" has "+player+" players.";
        }
    }

    class GameWithTimeLimit : Game
    {
        private int limit;
        public GameWithTimeLimit(String name, int player, int limit) : base(name,player)
        {
            this.limit = limit;
        }
        public override string ToString()
        {
            return base.ToString() + " And has a time limit " + limit + " minutes.";
        }

        public static void mainGame()
        {
           
            Console.WriteLine("Enter the game name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the maximum number of players: ");
            int players = int.Parse(Console.ReadLine());
            Console.WriteLine("Does the game has time limit or not (y/n)");
            char ch = char.Parse(Console.ReadLine());
            if(ch == 'Y' || ch == 'y'){
                Console.WriteLine("Enter the time limit: ");
                int limit = int.Parse(Console.ReadLine());
                GameWithTimeLimit gl = new GameWithTimeLimit(name, players, limit);
                Console.WriteLine( gl.ToString());
            }
            else
            {
                Game game = new Game(name, players);
                Console.WriteLine( game.ToString());
            }
        }
    }


    interface IOpenable
    {
        string Opensesame();
    }

    class TreasureBox : IOpenable
    {
        public string Opensesame()
        {
            return "Congratulations Here is your lucky win";
        }
    }
    class Parachute : IOpenable
    {
        public string Opensesame()
        {
            return "Have a thrilling experience flying in air";
        }
    }
    class Mystery
    {
        public void IOpenableMain()
        {
            Console.WriteLine("Enter a letter found in the paper (T/P): ");
            String str = Console.ReadLine(); 

            if (str.Equals("T"))
            {
                TreasureBox tb = new TreasureBox();
                Console.WriteLine(tb.Opensesame());
            }
            else
            {
                Parachute para = new Parachute();
                Console.WriteLine(para.Opensesame());
            }
        }
    }
}
