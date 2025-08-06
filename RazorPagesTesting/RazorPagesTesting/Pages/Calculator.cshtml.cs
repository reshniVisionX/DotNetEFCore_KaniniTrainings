using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTesting.Repository;

namespace RazorPagesTesting.Pages
{
    public class CalculatorModel : PageModel
    {
        private readonly ICalculator _service;
        public int Result { get; set; }

        public CalculatorModel(ICalculator service)
        {
            _service = service;
        }

        public void OnGet(int x, int y)
        {
            Result = _service.Add(x, y);
        }
     
    }
}
