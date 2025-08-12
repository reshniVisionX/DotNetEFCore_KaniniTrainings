using EFCore_MVC_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_CodeFirst.Controllers
{
    public class ItemsController : Controller
    {
        private readonly StudentContext _context;
        public ItemsController(StudentContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            IEnumerable<Items> its = _context.items.ToList();
            return View(its);
        }

        public IActionResult Details(int id)
        {
            Items itm = _context.items.FirstOrDefault(c => c.ItemId == id);
            return View(itm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Items itm)
        {
            _context.items.Add(itm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           Items its = _context.items.FirstOrDefault(c => c.ItemId == id);
            return View(its);
        }
        [HttpPost]
        public IActionResult Edit(int id,Items newitm)
        {
            Items extits = _context.items.FirstOrDefault(c => c.ItemId == id);
            extits.ItemName = newitm.ItemName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Items its = _context.items.FirstOrDefault(c => c.ItemId == id);
             _context.items.Remove(its);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }     
    }
}
