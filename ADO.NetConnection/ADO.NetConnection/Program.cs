using ADO.NetConnection;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //SQLServerConnection sq = new SQLServerConnection();
        //sq.SQLMain();

        RestaurantCRUD res = new RestaurantCRUD();
        res.RestaurantMain();
    }
}