using	System;
 using	System.Collections.Generic;
 using	System.Threading.Tasks;
 using	MVCSample.Models;

namespace MVCSample.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteTodoItemAsync();
        Task<bool> AddItemAsync(TodoItem newItem);
        
        Task<bool> MarkDoneAsync(Guid id);
    }
}
