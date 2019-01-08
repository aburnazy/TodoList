using System.Linq;
using TodoList.Core.Model;
using TodoList.Core.Model.Contracts;

namespace TodoList.Data.DB.Processor
{
    public class TodoProcessor: BaseDbContext<Todo>, ITodoProcessor
    {
        public TodoProcessor(string connectionString) : base(connectionString)
        {
        }

        public void Create(Todo newTodo)
        {
            Add<Todo>(newTodo);
            SaveChanges();
        }

        public void Update(int id, Todo modifiedTodo)
        {
            var todo = Find<Todo>(id);
            if (todo != null)
            {
                todo.Title = modifiedTodo.Title == todo.Title ? todo.Title : modifiedTodo.Title;
                todo.Description = modifiedTodo.Description == todo.Description ? todo.Description : modifiedTodo.Description;
                todo.Completed = modifiedTodo.Completed == todo.Completed ? todo.Completed : modifiedTodo.Completed;

                Update<Todo>(todo);
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var todo = Find<Todo>(id);
            if (todo != null)
            {
                Remove<Todo>(todo);
                SaveChanges();
            }            
        }
    }
}
