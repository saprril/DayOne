using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCSample.Data;
using MVCSample.Models;
using Microsoft.EntityFrameworkCore;
namespace MVCSample.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly AppDbContext _context;
        public TodoItemService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TodoItem[]> GetIncompleteTodoItemAsync()
        {
            return await _context.Items
                            .Where(x => x.IsDone == false)
                            .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            if (newItem == null || string.IsNullOrWhiteSpace(newItem.Title))
            {
                return false;
            }
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = newItem.DueAt?.ToUniversalTime();

            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return false;
            }
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }   
    }
}