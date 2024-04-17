using Microsoft.AspNetCore.Mvc;
using Tp_lab4.Entities;
using Tp_lab4.Service;

namespace Tp_lab4.Controllers
{
    public class ControllerTodoItem : ControllerBase
    {
        private readonly TodoItemService _todoItemService;
        private readonly UserService _userService;


        public ControllerTodoItem(TodoItemService todoItemService, UserService userService)
        {
            _todoItemService = todoItemService;
            _userService = userService;


        }

        [HttpGet]
        public IActionResult GetAllTodoItems()
        {
            var todoItem = _todoItemService.GetAllTodoItems();
            return Ok(todoItem);
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var todoItem = _todoItemService.GetItemById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }


    }
}
