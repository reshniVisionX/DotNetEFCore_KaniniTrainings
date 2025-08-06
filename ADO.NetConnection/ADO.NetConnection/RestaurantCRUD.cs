using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetConnection
{
    internal class RestaurantCRUD
    {
        public static SqlConnection con;
        public void GetConnections()
        {
            con = new SqlConnection("server = DAISH\\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;");

            con.Open();

        }
        public void RestaurantMain()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Enter your choice : ");
                Console.WriteLine("1. view all table");
                Console.WriteLine("2. Insert into a table");
                Console.WriteLine("3. Update the table");
                Console.WriteLine("4. Delete from table");
                Console.WriteLine("5. Search in table");
                Console.WriteLine("6. Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewTables();
                        break;
                    case 2:
                        InsertTable();
                        break;
                    case 3:
                        UpdateTable();
                        break;
                    case 4:
                        DeleteInTable();
                        break;
                    case 5:
                        SearchOption();
                        break;
                    case 6:
                        Console.WriteLine("Exiting....");
                        return;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (true);
        }
        public void ViewTables()
        {
            GetConnections();
            string[] tables = { "restaurant", "menulist", "orders" };
            foreach (string table in tables) {
                Console.WriteLine($"---------- {table} ----------");
                SqlCommand cmd = new SqlCommand($"select * from {table}", con);
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    for (int i = 0; i < res.FieldCount; i++)
                    {
                        Console.Write($"{res.GetName(i)} : {res[i]}  ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                res.Close();
            }
        }
        public string findTableName()
        {
            Console.WriteLine("Enter your choice ");
            Console.Write(" 1. Restaurants  ");
            Console.Write(" 2. Menu List ");
            Console.Write(" 3. Orders");
            int choice = int.Parse(Console.ReadLine());
            return (choice == 1 ? "restaurants" : (choice == 2 ? "menulist" : "orders"));
        }
        public void InsertTable()
        {
            GetConnections();
            String tablename = findTableName();
            switch (tablename)
            {
                case "restaurants":
                    Console.Write("Enter Restaurant Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter Phone Number: ");
                    string phno = Console.ReadLine();

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Restaurant (name, city, phno) VALUES (@name, @city, @phno)", con);
                    cmd1.Parameters.AddWithValue("@name", name);
                    cmd1.Parameters.AddWithValue("@city", city);
                    cmd1.Parameters.AddWithValue("@phno", phno);
                    cmd1.ExecuteNonQuery();
                    Console.WriteLine("Inserted into Restaurant.");
                    break;
                case "menulist":
                    Console.Write("Enter Dish Name: ");
                    string dish = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Category: ");
                    string cat = Console.ReadLine();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO MenuList (dish_name, price, category) VALUES (@dish, @price, @cat)", con);
                    cmd2.Parameters.AddWithValue("@dish", dish);
                    cmd2.Parameters.AddWithValue("@price", price);
                    cmd2.Parameters.AddWithValue("@cat", cat);
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Inserted into MenuList.");
                    break;
                case "orders":
                    Console.Write("Enter Customer Name: ");
                    string cust = Console.ReadLine();
                    Console.Write("Enter Quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    Console.Write("Enter Total Amount: ");
                    int total = int.Parse(Console.ReadLine());

                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Orders (CustomerName, quantity, TotalAmount) VALUES (@cust, @qty, @total)", con);
                    cmd3.Parameters.AddWithValue("@cust", cust);
                    cmd3.Parameters.AddWithValue("@qty", qty);
                    cmd3.Parameters.AddWithValue("@total", total);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Inserted into Orders.");
                    break;
                default:
                    Console.WriteLine("Invalid table entry");
                    break;
            }
        }
        public void UpdateTable()
        {
            GetConnections();
            String tablename = findTableName();
            switch (tablename)
            {
                case "restaurants":
                    Console.WriteLine("Enter the restaurant id to update : ");
                    int r_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the new city : ");
                    string city = Console.ReadLine();
                    SqlCommand cmd = new SqlCommand("UPDATE Restaurant SET name=@name ,city=@city WHERE rest_id=@id", con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", r_id);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Restaurant updated");
                    break;
                case "menulist":
                    Console.Write("Enter Menu ID to update: ");
                    int mid = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Dish Name: ");
                    string dish = Console.ReadLine();
                    Console.Write("Enter New Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new category: ");
                    string categ = Console.ReadLine();
                    SqlCommand cmd2 = new SqlCommand("UPDATE MenuList SET dish_name=@dish, price = @price, category = @cat WHERE menu_id = @id", con);
                    cmd2.Parameters.AddWithValue("@price", price);
                    cmd2.Parameters.AddWithValue("@id", mid);
                    cmd2.Parameters.AddWithValue("@cat", categ);
                    cmd2.Parameters.AddWithValue("@dish", dish);
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Menu item updated.");
                    break;
                case "orders":
                    Console.Write("Enter Order ID to update: ");
                    int oid = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the total amount: ");
                    int amt = int.Parse(Console.ReadLine());
                    SqlCommand cmd3 = new SqlCommand("UPDATE Orders SET quantity = @qty, totalamount = @amt WHERE order_id = @id", con);
                    cmd3.Parameters.AddWithValue("@qty", qty);
                    cmd3.Parameters.AddWithValue("@id", oid);
                    cmd3.Parameters.AddWithValue("@amt", amt);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Order updated.");
                    break;
                default:
                    Console.WriteLine("Invalid table entry");
                    break;
            }
        }
        public void DeleteInTable()
        {
            GetConnections();
            String tablename = findTableName();
            switch (tablename)
            {
                case "restaurants":
                    Console.Write("Enter Restaurant ID to delete: ");
                    int rid = int.Parse(Console.ReadLine());

                    SqlCommand cmd1 = new SqlCommand("DELETE FROM Restaurant WHERE rest_id = @id", con);
                    cmd1.Parameters.AddWithValue("@id", rid);
                    cmd1.ExecuteNonQuery();
                    Console.WriteLine($"Restaurant with id {rid} deleted.");
                    break;
                case "menulist":
                    Console.Write("Enter Menu ID to delete: ");
                    int mid = int.Parse(Console.ReadLine());

                    SqlCommand cmd2 = new SqlCommand("DELETE FROM MenuList WHERE menu_id = @id", con);
                    cmd2.Parameters.AddWithValue("@id", mid);
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine($"Menu item with id {mid} deleted.");
                    break;
                case "orders":
                    Console.Write("Enter Order ID to delete: ");
                    int oid = int.Parse(Console.ReadLine());

                    SqlCommand cmd3 = new SqlCommand("DELETE FROM Orders WHERE order_id = @id", con);
                    cmd3.Parameters.AddWithValue("@id", oid);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine($"Order with {oid} deleted.");
                    break;
                default:
                    Console.WriteLine("Invalid table entry");
                    break;
            }
        }
        public void SearchOption()
        {
            GetConnections();
            Console.WriteLine("\nSearch Options:");
            Console.WriteLine("1. Search Restaurant by City");
            Console.WriteLine("2. Search Orders by Customer Name");
            Console.WriteLine("3. Search MenuList by Category");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            SqlCommand cmd = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter City Name: ");
                    string city = Console.ReadLine();
                    cmd = new SqlCommand("SELECT * FROM Restaurant WHERE city = @city", con);
                    cmd.Parameters.AddWithValue("@city", city);
                    break;

                case 2:
                    Console.Write("Enter Customer Name: ");
                    string name = Console.ReadLine();
                    cmd = new SqlCommand("SELECT * FROM Orders WHERE CustomerName = @name", con);
                    cmd.Parameters.AddWithValue("@name", name);
                    break;

                case 3:
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();
                    cmd = new SqlCommand("SELECT * FROM MenuList WHERE category = @category", con);
                    cmd.Parameters.AddWithValue("@category", category);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    con.Close();
                    return;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("No matching records found.");
            }
            else
            {
               
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i)} : {reader[i]}  ");
                    }
                    Console.WriteLine();
                }
            }

            reader.Close();
            con.Close();
        }
    }
}
