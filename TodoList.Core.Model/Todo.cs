using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoList.Core.Model
{
    [Table("TodoItem")]
    public class Todo: BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("descr")]
        public string Description { get; set; }

        [Column("is_completed")]
        public bool Completed { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; }

        public Todo()
        {
        }

        public Todo(int id, string title, string descr = "")
        {
            Id = id;
            Title = title;
            Description = descr;
            Completed = false;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public Todo(int id, string title, string descr, bool completed, DateTimeOffset createdAt)
        {
            Id = id;
            Title = title;
            Description = descr;
            Completed = completed;
            CreatedAt = createdAt;
        }

    }
}
