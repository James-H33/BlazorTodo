using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly LocalStorage _storage;
        public TodoService(LocalStorage storage)
        {
            _storage = storage;
        }
        public List<TodoModel> GetAll()
        {
            var todosFromStorage = _storage.GetItem("todos");

            if (String.IsNullOrEmpty(todosFromStorage)) {
                return new List<TodoModel>();
            }

            try {
                var todos = JsonConvert.DeserializeObject<List<TodoModel>>(todosFromStorage);

                return todos;
            } catch {
                return new List<TodoModel>();
            }
        }

        public void Update(List<TodoModel> todos)
        {
            var todosForStorage = JsonConvert.SerializeObject(todos);
            _storage.SetItem("todos", todosForStorage);
        }
    }
}