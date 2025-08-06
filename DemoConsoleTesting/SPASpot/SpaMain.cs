using System;
using System.Collections.Generic;
using System.Linq;

namespace SPASpot
{
    public class SpaService
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; }

        public SpaService(string serviceName, double price, int duration)
        {
            ServiceName = serviceName;
            Price = price;
            Duration = duration;
            CreatedAt = DateTime.Now;
        }
    }

    public class SpaMain
    {
        private List<SpaService> spaList = new List<SpaService>();

        public void AddService(string name, double price, int duration)
        {
            spaList.Add(new SpaService(name, price, duration));
        }

        public List<SpaService> GetAllServices()
        {
            return spaList;
        }
        public void UpdateServicePrice(string name, int newPrice)
        {
            var service = spaList.FirstOrDefault(s => s.ServiceName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (service == null)
                throw new Exception("Service not found.");
            if (newPrice < 0)
                throw new ArgumentException("Price cannot be negative.");

            service.Price = newPrice;
        }


        public bool DeleteService(string name)
        {
            var service = spaList.FirstOrDefault(s => s.ServiceName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (service != null)
            {
                spaList.Remove(service);
                return true;
            }
            return false;
        }

        public void ClearServices()
        {
            spaList.Clear(); 
        }
    }
}
