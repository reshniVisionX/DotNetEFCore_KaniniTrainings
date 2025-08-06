using ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
         GenericsMain gm = new GenericsMain();
        gm.CallGenerics();

       // GameWithTimeLimit.mainGame();

        //Mystery my = new Mystery();
        //my.IOpenableMain();

        //Console.Write("Enter account holder name: ");
        //string name = Console.ReadLine();
        //Console.Write("Enter account type (Savings/Current): ");
        //string accType = Console.ReadLine();
        //Console.Write("Enter your balance: ");
        //decimal balance = decimal.Parse(Console.ReadLine());

        //Account account = new Account(accType, balance, name);

        //int choice;
        //do
        //{
        //    Console.WriteLine("\nEnter your choice: ");
        //    Console.WriteLine("1. Deposit Funds");
        //    Console.WriteLine("2. Withdraw Funds");
        //    Console.WriteLine("3. Display Account Details");
        //    Console.WriteLine("4. Exit");
        //    Console.Write("Enter your choice: ");

        //    choice = int.Parse(Console.ReadLine());

        //    switch (choice)
        //    {
        //        case 1:
        //            Console.Write("Enter amount to deposit: ");
        //            decimal depositAmount = decimal.Parse(Console.ReadLine());
        //            account.DepositFunds(depositAmount);
        //            break;

        //        case 2:
        //            Console.Write("Enter amount to withdraw: ");
        //            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
        //            account.WithdrawFunds(withdrawAmount);
        //            break;

        //        case 3:
        //            account.DisplayData();
        //            break;

        //        case 4:
        //            Console.WriteLine("Thank you for banking with us!");
        //            break;

        //        default:
        //            Console.WriteLine("Invalid choice. Please try again.");
        //            break;
        //    }

        //} while (choice != 4);

        //Product product = new Product();
        //product.Main();

        //Console.WriteLine("Enter the make for car : ");
        //String make = Console.ReadLine();
        //Console.WriteLine("Enter the model : ");
        //String model = Console.ReadLine();
        //Console.WriteLine("Enter the year : ");
        //int year = Convert.ToInt32(Console.ReadLine());
        //Car car = new Car(make,model,year);
        //car.GetInfo();
        //Console.WriteLine("Enter the make1 for motorcycle : ");
        //String make1 = Console.ReadLine();
        //Console.WriteLine("Enter the model1 : ");
        //String model1 = Console.ReadLine();
        //Console.WriteLine("Enter the year1 : ");
        //int year1 = Convert.ToInt32(Console.ReadLine());
        //Motorcycle mc = new Motorcycle(make1, model1, year1);
        //car.GetInfo();
        //mc.GetInfo();

        //Console.WriteLine("Enter the name : ");
        //String name = Console.ReadLine();
        //Console.WriteLine("Enter the grade : ");
        //String  grade = Console.ReadLine();
        //Console.WriteLine("Enter the age : ");
        //int age = Convert.ToInt32(Console.ReadLine());
        //Student std = new Student(name, age, grade);
        //std.PrintData();

        //Arrays ar = new Arrays();
        //ar.ReadArray();

        //SamsungA12 phone = new SamsungA12(8845678910, "Reshni", 1234);
        //phone.makeCall();      
        //phone.sendMessage();   
        //phone.takePicture();

        //Motorola moto = new Motorola(9988776655, "shree", 54321);
        //moto.makeCall();

        //Class2 sealedClass = new Class2();
        //sealedClass.display();

        //SamsungA11 samsung = new SamsungA11(9876543210, "Resh", 1234);
        //samsung.display(); 
        //samsung.MakeCall(); 
        //samsung.SendMessage(); 
        //samsung.Display();

        //Motorolas mot = new Motorolas(9123456780, "Shree", 4321);
        //mot.display(); 
        //mot.Display();


        //Console.WriteLine("--- Employee Examples ---");
        //Employee emp1 = new Employee();
        //Console.WriteLine();
        //Employee emp2 = new Employee("India", 35, "Renu");
        //emp2.display();

        //Console.WriteLine("\n--- Permanent Employee Examples ---");
        //PermanentEmployee pemp = new PermanentEmployee(11, 7234567890, 75000, "Canada", 28, "Alice");
        //pemp.display();

        //Console.WriteLine("\n--- Temporary Employee Examples ---");
        //TemporaryEmployee temp = new TemporaryEmployee(12, 9876543210, 50000, "Canada", 25, "Nivi");
        //temp.display();

        //TemporaryEmployee temp2 = new TemporaryEmployee(temp);
        //Console.WriteLine("\n--- Copied Temporary Employee ---");
        //temp2.display();

        //// method overloading
        //Console.WriteLine();
        //Print();
        //Console.WriteLine(Print("shiva", "developer"));
        //Console.WriteLine(Print(567.98m));
    }
    static void Print()
    {
        Console.WriteLine("Hello Kanini...");
    }
    static String Print(String name, String value)
    {
        Console.WriteLine("Name is " + name + " works as a " + value);
        return "printed";
    }
    static decimal Print(decimal value)
    {
        Console.WriteLine("The value received is " + value);
        return value * value;
    }
}