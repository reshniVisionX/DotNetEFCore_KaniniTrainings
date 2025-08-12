using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirst.Models;

namespace MVC_CodeFirst.Controllers
{
    public class CategoryController : Controller
    {
        //Action methods are public methods in a controller class that handle incoming requests.
        private readonly MainContext _context;
        public CategoryController(MainContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> catlst = _context.Categories.ToList();
            return View(catlst);
        }


    }
}
