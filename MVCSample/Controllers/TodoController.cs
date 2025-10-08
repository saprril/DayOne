using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCSample.Services;
using MVCSample.Models;

namespace MVCSample.Controllers
{
    public class TodoController : Controller
    {
        //	Actions	go	here
        private readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteTodoItemAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };
            return View(model);
        }
    }
}