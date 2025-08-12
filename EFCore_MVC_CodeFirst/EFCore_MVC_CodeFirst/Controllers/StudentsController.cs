using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCore_MVC_CodeFirst.Models;

namespace EFCore_MVC_CodeFirst.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;
        internal object items;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Students
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.students.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {
            var data = await _context.students
                .Include(s => s.items) 
                .ToListAsync();

            return View(data);
        }
     
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students
                .Include(s => s.items)
                .ToListAsync();
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        //public IActionResult Create()
        //{            
        //    return View();
        //}
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.items, "ItemId", "ItemName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("studId,studName,dept")] Students students)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(students);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(students);
        //}
        public async Task<IActionResult> Create([Bind("studId,studName,dept,ItemId,ItemName")] Students students)
        {      
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  
        }


        // GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ItemId"] = new SelectList(_context.items, "ItemId", "ItemName");
        //    var students = await _context.students.FindAsync(id);
        //    if (students == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(students);
        //}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            // Pass the dropdown list with the student's current ItemId selected
            ViewData["ItemId"] = new SelectList(_context.items, "ItemId", "ItemName", student.ItemId);

            return View(student);       
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public async Task<IActionResult> Edit(int id, [Bind("studId,studName,dept,ItemId")] Students students)
        {
            if (id != students.studId)
            {
                return NotFound();
            }
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                              
                    if (!StudentsExists(students.studId))
                    {
                        return NotFound();
                    }             
            ViewData["ItemId"] = new SelectList(_context.items, "ItemId", "ItemName", students.ItemId);
            return View(students);
        
        }


        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students.Include(s => s.items)
              .FirstOrDefaultAsync(m => m.studId == id);

            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.students.FindAsync(id);
            if (students != null)
            {
                _context.students.Remove(students);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.students.Any(e => e.studId == id);
        }
    }
}
