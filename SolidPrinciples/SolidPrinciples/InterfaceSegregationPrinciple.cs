using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    // Clients shouldn’t be forced to depend on interfaces they don’t use.
    //Avoiding “fat” interfaces
    interface Delivery
    {
        void Delivery();
        void DeliveryCharge();
      
    }
    interface IPurchase
    {
        void OnlinePayment(int amt);
        void SaveToDB(String name,String item,String amt);
        void SendEmail(String email);
        public void Dummy()
        {
            Console.WriteLine("This is dummy method in Delivery interface");
        }
    }
    class StorePurchase : IPurchase
    {
        public void OnlinePayment(int amt)
        {
            Console.WriteLine("Store payment done for amt " + amt);
        }

        public void SaveToDB(string name, string item, string amt)
        {
            Console.WriteLine("Save Data to db " + name + " " + item + " - " + amt);
        }

        public void SendEmail(string email)
        {
            Console.WriteLine("Sending email to " + email);
        }
        public void Dummy()
        {
            Console.WriteLine("The is dummy method in StorePurchase");  
        }
    }
    class OnlinePurchase : IPurchase, Delivery
    {
      

        public void DeliveryCharge()
        {
            Console.WriteLine("Delivey charge is added");
        }

        public void OnlinePayment(int amt)
        {
            Console.WriteLine("Online payment done for amt " + amt);
        }
        public void Delivery()
        {
            Console.WriteLine("Online delivery successfull");
        }
        public void SaveToDB(string name, string item, string amt)
        {
            Console.WriteLine("Save Data to db " + name + " " + item + " - " + amt);
        }

        public void SendEmail(string email)
        {
            Console.WriteLine("Sending email to " + email);
        }
    }
    public class InterfaceSegregationPrinciple
    {
        public void Start()
        {
            Console.WriteLine("*Store Purchase*");
            IPurchase store = new StorePurchase();
            store.Dummy();
            StorePurchase storePurchase = new StorePurchase();
            store.OnlinePayment(1000);
            store.SaveToDB("reshni", "Shoes", "1000");
            store.SendEmail("reshni@email.com");
            storePurchase.Dummy();

            Console.WriteLine("\n*Online Purchase*");
            OnlinePurchase online = new OnlinePurchase();
            online.OnlinePayment(2000);
            online.DeliveryCharge();
            online.Delivery();
            online.SaveToDB("shiva", "Phone", "2000");
            online.SendEmail("shiva@email.com");

        }
    }
}
