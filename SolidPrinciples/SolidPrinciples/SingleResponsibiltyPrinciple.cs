using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidPrinciples.ProcessOrder;

namespace SolidPrinciples
{
    public class SingleResponsibiltyPrinciple
    {
        public void Start()
        {
            Console.Write("Enter Order Type (Online / Store): ");
            string Type = Console.ReadLine();
            if (Type == "Online")
            {
                Console.WriteLine("Your order is placed online successfully");
            }
            else if (Type == "Store")
            {
                Console.WriteLine("Your store order is delivered and payment successful");
            }
            SaveToDatabase db = new SaveToDatabase();
            SendEmail email = new SendEmail();

            db.SaveDB("U1", "Shampoo", 250);
            email.Emailing("reshni@gmail.com", "Resh");
        }
    }
    public class ProcessOrder
    {
      public void OrderMethod(String type)
        {
            if (type == "Online")
            {
                Console.WriteLine("Your order is placed online successfully");
            }else if (type == "Store")
            {
                Console.WriteLine("Your store order is delivered and payment successful");
            }else
            {
                Console.WriteLine("Invalid Order");
            }
        }

        public class SaveToDatabase
        {
            public void SaveDB(String id,String p_name,int amt)
            {
                Console.WriteLine($"User id {id} purchased {p_name} of total price {amt}");
                Console.WriteLine("Saved data to DB Sucessfully");
            }
        }

        public class SendEmail
        {
            public void Emailing(String mailid,String name)
            {
                Console.WriteLine($"Sending conformation mail to {mailid} - {name}");
                Console.WriteLine("Email sent successfully");
            }
        }
    }
}
