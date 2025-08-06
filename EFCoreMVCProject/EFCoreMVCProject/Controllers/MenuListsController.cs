using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreMVCProject.Models;

namespace EFCoreMVCProject.Controllers
{
    public class MenuListsController : Controller
    {
        private readonly MyDemoDbContext _context;

        public MenuListsController(MyDemoDbContext context)
        {
            _context = context;
        }

        // GET: MenuLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuLists.ToListAsync());
        }

        // GET: MenuLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuList = await _context.MenuLists
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuList == null)
            {
                return NotFound();
            }

            return View(menuList);
        }

        // GET: MenuLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,DishName,Price,Category")] MenuList menuList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuList);
        }

        // GET: MenuLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuList = await _context.MenuLists.FindAsync(id);
            if (menuList == null)
            {
                return NotFound();
            }
            return View(menuList);
        }

        // POST: MenuLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,DishName,Price,Category")] MenuList menuList)
        {
            if (id != menuList.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuListExists(menuList.MenuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuList);
        }

        // GET: MenuLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuList = await _context.MenuLists
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuList == null)
            {
                return NotFound();
            }

            return View(menuList);
        }

        // POST: MenuLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuList = await _context.MenuLists.FindAsync(id);
            if (menuList != null)
            {
                _context.MenuLists.Remove(menuList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuListExists(int id)
        {
            return _context.MenuLists.Any(e => e.MenuId == id);
        }
    }
}
