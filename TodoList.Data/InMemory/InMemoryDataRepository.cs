using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using TodoList.Core.Model;
using TodoList.Core.Model.Contracts;

namespace TodoList.Data.InMemory
{
    public class InMemoryDataRepository: ITodoProvider, ITodoProcessor
    {
        private static int lastId = 0;

        private static int NextId()
        {
            Interlocked.Increment(ref lastId);

            return lastId;
        }

        private static ConcurrentDictionary<int, Todo> todos = new ConcurrentDictionary<int, Todo>
        {
                [NextId()] = new Todo(1, "Learn C#", "Need to learn the C# Programming language for my next job!"),
                [NextId()] = new Todo(2, "Get Used to Visual Studio", "Learn the concepts used in VS, the Shortcuts and so on ..."),
                [NextId()] = new Todo(3, "Read the TDD Book", "Read the `Test-Driven-Development by Example` book my Kent Beck."),
                [NextId()] = new Todo(4, "Get some sleep ...")
        };

        public IEnumerable<Todo> FindAll()
        {
            return todos.Values;
        }

        public Todo FindById(int id)
        {
            return todos[id];
        }

        public void Create(Todo newTodo)
        {
            int nextId = NextId();
            newTodo.Id = nextId;
            todos[nextId] = newTodo;
        }

        public void Update(int id, Todo modifiedTodo)
        {
            if (todos.ContainsKey(id))
            {
                todos[id] = modifiedTodo;
            }
        }

        public void Delete(int id)
        {
            todos.TryRemove(id, out var todo);
        }
    }
}
