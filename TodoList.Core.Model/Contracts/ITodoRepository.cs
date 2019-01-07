using System.Collections.Generic;

namespace TodoList.Core.Model.Contracts
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> FindAll();
        Todo FindById(int id);
        void Create(Todo newTodo);
        void Update(int id, Todo modifiedTodo);
        void Delete(int id);
    }
}
