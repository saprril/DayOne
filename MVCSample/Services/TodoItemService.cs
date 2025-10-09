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
    }
}