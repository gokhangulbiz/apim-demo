﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIM.Demo.AppService.Data;
using APIM.Demo.AppService.Models;

namespace APIM.Demo.AppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoItemsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItem()
        {
            return await _context.ToDoItem.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItem.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
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

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItem.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItem34w23423", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItem.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItem.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(long id)
        {
            return _context.ToDoItem.Any(e => e.Id == id);
        }
    }
}
