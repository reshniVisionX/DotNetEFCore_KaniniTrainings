using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class ProductReview
    {
        public static SqlConnection con;
        public void ReviewMain()
        {
            int choice = 0;
            Console.WriteLine("Welcome to the Product Review System");
            do
            {
                Console.WriteLine("1. Add a Product Review");
                Console.WriteLine("2. View All Product Reviews");
                Console.WriteLine("3. Update a Product Review");
                Console.WriteLine("4. Delete a Product Review");
                Console.WriteLine("5. Count of Product Reviews");
                Console.WriteLine("6. Search all the reviews by data");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddProductReview();
                        break;
                    case 2:
                        ViewAllReview();
                        break;
                    case 3:
                        UpdateReview();
                        break;
                    case 4:
                        DeleteReview();
                        break;
                    case 5:
                        CountReview();
                        break;
                    case 6:
                        SearchReviewByDate();
                        break;
                    case 7:
                        Console.WriteLine("Exiting the Product Review System.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }while(choice != 7);
        }

        public void GetConnection()
        {
            con = new SqlConnection("server = DAISH\\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;");
            con.Open();
        }
        public void AddProductReview()
        {
            GetConnection();
            Console.WriteLine("Enter the product Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter your email id:");
            String email = Console.ReadLine();  
            Console.WriteLine("Enter the product Review:");
            String review = Console.ReadLine();
            Console.WriteLine("Enter the product Rating:");
            int rating = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("InsertInto", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Review", review);
            cmd.Parameters.AddWithValue("@Rating", rating);
            cmd.ExecuteNonQuery();
           
            Console.WriteLine("Product Review Added Successfully!");

        }
        public void ViewAllReview()
        {
            GetConnection();
            SqlCommand cmd = new SqlCommand("ViewAllReview", con);
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader res= cmd.ExecuteReader();
            while (res.Read())
            {
                Console.Write("Product Name: " + res["PName"] + ", "+" Email: " + res["Email"]+", "+" Review:" + res["Review"]+" Rating: " + res["Rating"]+", Date: " + res["CreatedAt"]+"\n");

            }
        }
        public void UpdateReview()
        {
            GetConnection();
            Console.WriteLine("Enter the product Name to update:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the new product review:");
            String newReview = Console.ReadLine();
            Console.WriteLine("Enter the new product rating:");
            int newRating = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("UpdateReview", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", name);
            cmd.Parameters.AddWithValue("@NewReview", newReview);
            cmd.Parameters.AddWithValue("@NewRating", newRating);
            int res = cmd.ExecuteNonQuery();
       
            if (res>0)
            {
                Console.WriteLine("Product Review Updated Successfully!");
            }
            else
            {
                Console.WriteLine("No review found with the given product name.");
            }
            
        }
        public void DeleteReview()
        {
            GetConnection();
            Console.WriteLine("Enter the product Name to delete:");
            String name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("DeleteReview", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", name);
            int res = cmd.ExecuteNonQuery();
            if(res>0)
            {
                Console.WriteLine("Product Review Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("No review found with the given product name.");
            }
        }
        public void CountReview()
        {
            GetConnection();
            Console.Write("The total count of the product reviews is:");
            SqlCommand cmd = new SqlCommand("CountReview", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            try {
                count =(int)cmd.ExecuteScalar();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message+" "+e.StackTrace);
            }
          
            if(count == 0)
            {
                Console.WriteLine("No reviews found.\n");
            }
            else
            {
                Console.WriteLine(count+"\n");
            }
        }
        

        public void SearchReviewByDate()
        {
            GetConnection();
            Console.WriteLine("Enter the date to search reviews as (yyyy-mm-dd):");
            string dateInput = Console.ReadLine();
            DateTime date;
            SqlCommand cmd = new SqlCommand("SearchReviewDate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", dateInput);
            SqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine("Product Name: " + red["PName"] + ", Email: " + red["Email"] + ", Review: " + red["Review"] + ", Rating: " + red["Rating"] + ", Date: " + red["CreatedAt"]);
            }

        }
      
        

    }
}
