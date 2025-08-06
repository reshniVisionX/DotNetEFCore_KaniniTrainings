using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetConnection
{
    internal class SQLServerConnection
    {
        public static SqlConnection con;
        public void SQLMain()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Enter your choice : ");
                Console.WriteLine("1. Create a table");
                Console.WriteLine("2. Insert into a table");
                Console.WriteLine("3. Update the table");
                Console.WriteLine("4. Delete from table");
                Console.WriteLine("5. Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateTable();
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
                        Console.WriteLine("Exiting....");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (true);
        }
        public void GetConnections()
        {
          con = new SqlConnection("server = DAISH\\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;");
          
            con.Open();
          
        }
        public void CreateTable()
        {
            GetConnections();
            
            SqlCommand cmd = new SqlCommand("create table Product(Prod_id int primary key, Pro_name varchar(20), price float not null);", con);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table created successfully");

        }
        public void InsertTable()
        {
            GetConnections();
            SqlCommand cmd = new SqlCommand("INSERT INTO Product (Prod_id, Pro_name, price) VALUES (@id, @name, @price);",con);
            Console.WriteLine("Enter the data to insert into table : ");
            Console.WriteLine("Enter the product id : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the product name : ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the product price : ");
            float price = float.Parse(Console.ReadLine());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            Console.WriteLine("The data is inserted into the table successfully");
        }
        public void UpdateTable()
        {
            GetConnections();
            Console.WriteLine("Enter the id you want to update : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name to be updated : ");
            String uname = Console.ReadLine();
            Console.WriteLine("Enter the price to be updated : ");
            float price = float.Parse (Console.ReadLine());
            SqlCommand cmd = new SqlCommand("UPDATE Product SET Pro_name = @name, price = @price WHERE Prod_id = @id;",con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", uname);
            cmd.Parameters.AddWithValue("@price", price);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine(" Record Updated ");
            }
            else
            {
                Console.WriteLine("Error in updating the record");
            }

        }
        public void DeleteInTable()
        {
            GetConnections();
            Console.WriteLine("Enter the product id to delete : ");
            int id = int.Parse(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Prod_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", id);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine(" Record Deleted ");
            }
            else
            {
                Console.WriteLine("Error in deleting the record");
            }
        }
    }
}
