﻿using CShop.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CShop.Controllers
{
    [ApiController]
    [Route("~/cshop-api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseController(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll([FromQuery] string[] includes = null, [FromQuery] int skip = 0, [FromQuery] int top = 9999)
        {
            IQueryable<T> query = _dbSet;
            int totalCount = await query.CountAsync();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            var data = await query.Skip(skip * top).Take(top).ToListAsync();
            int count = await query.Skip(skip * top).Take(top).CountAsync();
            var response = new
            {
                totalCount = totalCount,
                data = data,
                count = count
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> Get(Guid id, [FromQuery] string[] includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            var item = await query.FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Id") == id);
            //var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody] T newItem)
        {
            _dbSet.Add(newItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = (newItem as dynamic).Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] T updatedItem)
        {
            if ((updatedItem as dynamic).Id != id)
            {
                return BadRequest();
            }

            _context.Entry(updatedItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
