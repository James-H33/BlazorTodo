using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoService
    {
        List<TodoModel> GetAll();
        void Update(List<TodoModel> todos);
    }
}