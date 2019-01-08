using System.Collections.Generic;

namespace TodoList.Core.Model.Contracts
{
    public interface ITodoProvider
    {
        IEnumerable<Todo> FindAll();
        Todo FindById(int id);
    }
}
