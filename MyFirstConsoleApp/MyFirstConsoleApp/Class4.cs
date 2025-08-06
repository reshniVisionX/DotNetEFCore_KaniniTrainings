
 internal class Assignment3
    {
     public void PrintName()
     {
        Console.WriteLine("Enter your firstname: ");
        String firstname = Console.ReadLine();
        Console.WriteLine("Enter your lastname: ");
        String lastname = Console.ReadLine();
        Console.WriteLine($"Full name: {firstname} {lastname}");
     }
    public void DisplayReverse()
    {
        Console.WriteLine("Enter a sentence");
        String sentence = Console.ReadLine();
        String[] arr = sentence.Split(" ");
        int len = arr.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + " ");
        }
    }


  }

class Account
{
    private int id;
    private String acc_type;
    private double balance;

    public Account(int id, string acc_type, double balance)
    {
        this.id = id;
        this.acc_type = acc_type;
        this.balance = balance;
    }
    public Account()
    {
        Console.WriteLine("Default constructor ");
    }
    public Account(int id ,String acc_type,double balance,int amt)
    {
        this.id = id;
        this.acc_type = acc_type;
        this.balance =balance;
        Console.WriteLine("Account id " + id);
        Console.WriteLine("Account type " + acc_type);
        Console.WriteLine("Balance " + balance);
       if(Withdraw(amt))
        {
            Console.WriteLine("Amount Withdrawn");
        }
        else
        {
            Console.WriteLine("Your balance is insufficient");
        }
        Console.WriteLine("New Balance " + this.balance);
    }
    public bool Withdraw(double amount)
    {
        if (balance < amount)
        {
            return false;
        }
        else
        {
            balance -= amount;
            return true;
        }
    }
    public void GetDetails()
    {
        Console.WriteLine("Account id : " + id);
        Console.WriteLine("Account type : " + acc_type);
        Console.WriteLine("Account balance : " + balance);
    }
}