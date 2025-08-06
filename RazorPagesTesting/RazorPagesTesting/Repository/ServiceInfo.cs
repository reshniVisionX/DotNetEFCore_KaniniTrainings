namespace RazorPagesTesting.Repository
{
    public class ServiceInfo:IService
    {
        public List<Service> GetAllServices()
        {
            return new List<Service>
            {
                new Service{Name="Haircut",Price=300,Duration=30},
                new Service{Name="Facial",Price=500,Duration=500}
            };
        }
    }
}
