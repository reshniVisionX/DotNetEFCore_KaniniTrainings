using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    //Subtypes must be substitutable for their base types without altering the correctness. like ostrich is a bird but cant have Fly interface
    public abstract class Payment
    {
        public abstract void ProcessOnlinePay(int amount);
    }
    public interface IDelivery
    {
        void Deliver();
    }
    public class StoreDelivery : Payment
    {
        public override void ProcessOnlinePay(int amt)
        {
            Console.WriteLine("Your online payment is successfull for store delivery."+amt);
        }
      
    }
    public class OnlineDelivery : Payment, IDelivery
    {
        public override void ProcessOnlinePay(int amt)
        {
            Console.WriteLine("Your online payment is successfull online delivery."+amt);
        }
        public void Deliver()
        {
            Console.WriteLine("Online delivery:  Your order is out for delivery.");
        }

        
    }



    internal class LiskovPrinciple
    {
        public void Start()
        {
            IDelivery delivery = new OnlineDelivery();
            delivery.Deliver();

            Payment payment = new OnlineDelivery();
            payment.ProcessOnlinePay(500);

            Console.WriteLine();

            payment = new StoreDelivery();
            payment.ProcessOnlinePay(700);
        }
    }
}
