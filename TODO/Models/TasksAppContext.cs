using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class TasksAppContext : DbContext
    {
        public TasksAppContext(DbContextOptions<TasksAppContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks{get;set;}
        public DbSet<Category> Categories { get; set; }
    }
}
