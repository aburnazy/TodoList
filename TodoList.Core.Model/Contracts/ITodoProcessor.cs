using System.Collections.Generic;

namespace TodoList.Core.Model.Contracts
{
    public interface ITodoProcessor
    {
        void Create(Todo newTodo);
        void Update(int id, Todo modifiedTodo);
        void Delete(int id);
    }
}
