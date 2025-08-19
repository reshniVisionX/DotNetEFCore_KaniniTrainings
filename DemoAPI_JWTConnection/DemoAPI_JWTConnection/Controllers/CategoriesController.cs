using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoAPI_JWTConnection.Model;
using Microsoft.AspNetCore.Authorization;

namespace DemoAPI_JWTConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CategoriesController : ControllerBase
    {
        private readonly MainContext _context;

        public CategoriesController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Categories>> GetCategories(int id)
        {
            var categories = await _context.Categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutCategories(int id, Categories categories)
        {
            if (id != categories.catId)
            {
                return BadRequest();
            }

            _context.Entry(categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Categories>> PostCategories(Categories categories)
        {
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategories", new { id = categories.catId }, categories);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.catId == id);
        }
    }
}
