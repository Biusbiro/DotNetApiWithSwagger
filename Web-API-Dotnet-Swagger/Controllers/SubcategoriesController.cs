﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Dotnet_Swagger.Data;
using Web_API_Dotnet_Swagger.Model;

namespace Web_API_Dotnet_Swagger.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public SubcategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Subcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> GetSubcategory(int id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return subcategory;
        }

        // PUT: api/Subcategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategory(int id, Subcategory subcategory)
        {
            if (id != subcategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoryExists(id))
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

        // POST: api/Subcategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subcategory>> PostSubcategory(Subcategory subcategory)
        {
            _context.SubCategories.Add(subcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcategory", new { id = subcategory.Id }, subcategory);
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubcategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.Id == id);
        }
    }
}
