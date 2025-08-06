using MyFirstConsoleApp;
using System;

class Voter
    {
        public int id;
        public String name;
        public int age;
        public Voter(int id, string name, int age)
        {

            this.id = id;
            this.name = name;
            this.age = age;
        }
        public void Display()
        {
            if (age >= 18)
            {
                Console.WriteLine(name + " with " + id + " is eligible to vote");
            }
            else
            {
                Console.WriteLine(name + " with " + id + " is not eligible to vote");
            }
        }
    }



class Program
{
    private static void Main(string[] args)
    {
        //--- Day 5 Assignment Collections --
        //Collections coll = new Collections();
        //coll.FlightTime();

        //Products pd = new Products();
        //pd.ProductMain();

        //BallsBowled bd = new BallsBowled();
        //bd.BallsProgram();

        Members mem = new Members();
        mem.MembersCall();

        //--- Day 3 Assignment ---
        //Assignment3 a3 = new Assignment3();
        //a3.PrintName();
        //a3.DisplayReverse();

        //Console.WriteLine("Enter id :");
        //int id = int.Parse(Console.ReadLine());
        //Console.WriteLine("Enter account type :");
        //String acc_type = Console.ReadLine();
        //Console.WriteLine("Enter account balance :");
        //double balance = double.Parse(Console.ReadLine());
        //Console.WriteLine("Enter amount to withdraw :");
        //int amt = int.Parse(Console.ReadLine());
        //Account ac = new Account(id,acc_type,balance,amt);


        //--- Day 2 Assignment ---

        //Console.WriteLine("Enter your name:");
        //String name = Console.ReadLine();
        //Console.WriteLine("Enter your age : ");
        //int age = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter your country :");
        //String country = Console.ReadLine();

        //Employees emp = new Employees(age,name,country);
        //emp.display();

        //Console.WriteLine("Enter a number: ");
        //int number = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("The square of the number is: "+FindSquare(number));
        //Console.WriteLine("The cube of the number is: "+FindCube(number));

        //Console.WriteLine("Enter a number x :");
        //int x = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter a number y :");
        //int y = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine(FindtheGreater(x, y));

        //Console.Write("Enter the number of pizza's bought: ");
        //int pizza = int.Parse(Console.ReadLine());
        //Console.Write("Enter the number of puff's bought: ");
        //int puffs = int.Parse(Console.ReadLine());
        //Console.Write("Enter the number of pepsi bought: ");
        //int pepsi = int.Parse(Console.ReadLine());
        //FindPrice(pizza,puffs, pepsi);

        //Console.WriteLine("Enter a value : ");
        //int num = 134;
        //FindMaxSignedByte(num);

        //int ids = 0, ages = 0;
        //String names;
        //Console.Write("Enter id ");
        //ids = Convert.ToInt32(Console.ReadLine());
        //Console.Write("Enter name ");
        //names = Console.ReadLine();
        //Console.Write("Enter age ");
        //ages = Convert.ToInt32(Console.ReadLine());
        //Employee em = new Manager(ids, names, ages);
        //em.ShowDept();
        //em.displayData("Reshni");


        //Console.WriteLine("End -- Multilevel inheritance");

        // --- Day 1 Assignment ---
        //Marks s = new Marks();
        //Console.WriteLine("Enter the eng ,math and assign marks ");
        //int eng = Convert.ToInt32(Console.ReadLine());
        //int math = Convert.ToInt32(Console.ReadLine());
        //String grade;
        //int assign = 10;
        //s.Analyze(eng, math, ref assign, out grade);
        //Console.WriteLine(eng + "-eng - math- " + math);
        //Console.WriteLine("Assign - "+assign);
        //Console.WriteLine("Grade - "+grade);

        //Console.Write("End--- ");

        //Console.Write("Enter the id, name and age ");
        //int id = Convert.ToInt32(Console.ReadLine());
        //String name = Console.ReadLine();
        //int age = Convert.ToInt32(Console.ReadLine());
        //Voter v1 = new Voter(id, name, age);
        //v1.Display();

        //Console.ReadLine();

        //Program prg = new Program();
        //Console.Write("Enter a number : ");
        //int number = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("FirstNumber is : "+prg.FirstDigit(number));
        //Console.WriteLine("LastNumber is : " + prg.LastDigit(number));
        //Console.WriteLine("The number is : "+prg.NumberType(number));
        //Console.Write("Enter a number to display its table : ");

        //int num = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine(num+"Table");
        //prg.Table(num);
        //Console.Write("Enter the employee salary : ");
        //decimal salary = Convert.ToDecimal(Console.ReadLine());
        //Console.WriteLine("The basic salary is : "+prg.Gross(salary));
    }
    static void FindMaxSignedByte(int num)
    {
        Console.WriteLine("The value is : " + num);
        sbyte res = (sbyte)num;
        Console.WriteLine("The maximum value of signed value is : " + res);
    }
    static void FindPrice(int pizza,int puffs,int pepsi)
    {
        Console.WriteLine("The cost of the pizza : " + pizza * 200);
        Console.WriteLine("The cost of the puffs : " + puffs * 40);
        Console.WriteLine("The cost of the pepsi :" + pepsi * 120);
        int total = (pizza * 200) + (puffs * 40) + (pepsi * 120);
        double gst = total * 0.12;
        Console.WriteLine("The GST 12% : " + gst);
        double cess = total * 0.05;
        Console.WriteLine("The CESS 5% :" + cess);
        double totalPrice = total + gst + cess;
        Console.WriteLine("The total price : "+totalPrice); 
    }
    static String FindtheGreater(int x,int y)
    {
        if (x <= y)
        {
            return "The result of x is less than y is true";
        }
        else
        {
            return "The result of x is less than y is false";
        }
    }
    static double FindSquare(int number)
    {
        return number * number;
    }
    static double FindCube(int number)
    {
        return number * number * number;
    }
    decimal Gross(decimal salary)
    {
        decimal hra = 0, da = 0,gsalary =0;
        if (salary <= 10000)
        {
            hra = salary * (0.2m);
            da = salary * (0.8m);
        }else if(salary >= 10001 && salary <= 20000)
        {
            hra = salary * (0.3m);
            da = salary * (0.9m);
        }
        else 
        {
            hra = salary * (0.3m);
            da = salary * (0.95m);
        }
         return salary + hra + da;
    }
    void Table(int num)
    {
        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} * {i} = {num*i}");
        }
    }

    String NumberType(int num)
    {
        String res = (num == 0 ? "Zero" : (num > 0 ? "Positive" : "Negative"));
        return res;
    }
    int FirstDigit(int num)
    {
        if (num == 0)
            return 0;
        int number = Math.Abs(num);
        int len = (int)(Math.Log10(number));
     
        int first = (int)(num / Math.Pow(10, len));
        return first;
    }
    int LastDigit(int num)
    {
        return num % 10;
    }
}