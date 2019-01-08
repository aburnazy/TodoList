using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Model;

namespace TodoList.Data.DB
{
    public class BaseDbContext<TModelEntity> : DbContext where TModelEntity: BaseModel 
    {
        public BaseDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbSet<TModelEntity> Entries { get; set; }
        public string ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
