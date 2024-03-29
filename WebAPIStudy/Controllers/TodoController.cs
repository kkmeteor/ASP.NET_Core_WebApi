﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskModels;
using WebAPIStudy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIStudy.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("GetString")]
        public async Task<ActionResult<string>> GetStringValue()
        {
            var task = StringTask.GetDtoTaskAsync();
            var taskResult = await task;
            var taskOk = Ok(task);
            return Ok(taskResult);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody] TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<TodoItem>> PutTodoItem(long id,[FromBody] TodoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)

        {
            var todoItem =await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
