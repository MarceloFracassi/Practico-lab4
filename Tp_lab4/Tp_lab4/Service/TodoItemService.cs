using Practico_labIV.dbContext;
using Tp_lab4.Entities;

namespace Tp_lab4.Service
{
    public class TodoItemService
    {
        private readonly DbContextPractico _context;
        public TodoItemService(DbContextPractico context)
        {
            _context = context;
        }

        public TodoItem GetItemById(int Id)
        {
            return _context.TodoItems.FirstOrDefault(p => p.Id_todo_item == Id);
        }
    }
}
