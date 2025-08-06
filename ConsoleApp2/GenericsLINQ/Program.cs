using GenericsLINQ;

internal class Program
{
    private static void Main(string[] args)
    {
        LINQ li = new LINQ();
        li.Linq();
        Console.WriteLine("Delegates... ");
        Delegates del = new Delegates();
        del.DelegatesMain();
    }

}