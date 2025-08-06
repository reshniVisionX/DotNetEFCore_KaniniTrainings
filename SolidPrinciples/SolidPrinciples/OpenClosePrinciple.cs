using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    // Software entities should be open for extension but closed for modification.
    interface IType
    {
        void OrderProcessing();

    }
    public class OnlineType : IType
    {
        public void OrderProcessing()
        {
            Console.WriteLine("Your online order is in process");
            Console.WriteLine("Your online order is delivered successfully");
        }
    }

    public class StoreType : IType
    {
        public void OrderProcessing()
        {
            Console.WriteLine("Your store order payment successfull");
            Console.WriteLine("Your store order is delivered successfully");
        }
    }
    class Processing
    {
        public void process(IType type)
        {
           type.OrderProcessing();
        }
    }
    public class OpenCloseMain
    {
        private Dictionary<string, IType> types = new(StringComparer.OrdinalIgnoreCase)
        {
          { "Online", new OnlineType() },
          { "Store", new StoreType() },
        };

        public void start()
        {

            Console.WriteLine("Enter the order type");
            String type = Console.ReadLine();
           
            if (types.TryGetValue(type, out var order))
            {
                new Processing().process(order);
            }
            else
            {
                Console.WriteLine("Invalid order type.");
            }
        }
    }
}
