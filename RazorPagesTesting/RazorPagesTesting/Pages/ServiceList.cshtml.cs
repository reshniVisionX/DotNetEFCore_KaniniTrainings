using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTesting.Repository;

namespace RazorPagesTesting.Pages
{
    public class ServiceListModel : PageModel
    {
        private readonly IService _ser;
        public List<Service> services { get; set; }
        public ServiceListModel(IService ser)
        {
            _ser = ser;
        }
        public void OnGet()
        {
            services = _ser.GetAllServices();
        }
    }
}
