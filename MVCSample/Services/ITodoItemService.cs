using	System;
 using	System.Collections.Generic;
 using	System.Threading.Tasks;
 using	MVCSample.Models;

namespace MVCSample.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteTodoItemAsync();
    }
}
