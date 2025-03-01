using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Data.Models;
using backend.Data.Dto;

namespace backend.Src_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoList()
        {
            return await _context.TodoList.ToListAsync();
        }

        // GET: api/TodoList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {
            var todoList = await _context.TodoList.FindAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            return todoList;
        }

        // PUT: api/TodoList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id, CreateUpdateTodoListDto updatedTodoList)
        {
            if (updatedTodoList == null)
                return BadRequest("Request body is required.");

            var existingTodoList = await _context.TodoList.FindAsync(id);
            if (existingTodoList == null)
                return NotFound("TodoList not found.");

            // Update hanya properti yang boleh diubah
            existingTodoList.Judul = updatedTodoList.Judul;
            existingTodoList.Description = updatedTodoList.Description;
            existingTodoList.OnUpdate();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Data has been modified by another process. Please try again.");
            }

            return NoContent();
        }

        // POST: api/TodoList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList(CreateUpdateTodoListDto createTodoList)
        {
            var todoList = new TodoList
            {
                Judul = createTodoList.Judul,
                Description = createTodoList.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.TodoList.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoList), new { id = todoList.TodoListId }, todoList);
        }

        // DELETE: api/TodoList/5 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var todoList = await _context.TodoList.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoList.Remove(todoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoList.Any(e => e.TodoListId == id);
        }
    }
}
