using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Core.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTimeOffset CreatedAt { get; }

        public Todo(int id, string title, string descr = "")
        {
            Id = id;
            Title = title;
            Description = descr;
            Completed = false;
            CreatedAt = DateTimeOffset.UtcNow;
        }
        
    }
}
