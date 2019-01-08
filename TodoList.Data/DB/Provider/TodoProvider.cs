using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Model;
using TodoList.Core.Model.Contracts;

namespace TodoList.Data.DB.Provider
{
    public class TodoProvider: BaseDbContext<Todo>, ITodoProvider
    {
        public TodoProvider(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Todo> FindAll()
        {
            return Entries.Select(todo => todo);
        }

        public Todo FindById(int id)
        {
            return Entries.FirstOrDefault(todo => todo.Id == id);
        }
    }
   
}
