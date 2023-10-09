using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess1.Configurations;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.DataAccess1.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public static object Login { get; set; }
        public DbSet<User> Users { get; set; }
        // Diğer DbSet özellikleri buraya eklenebilir
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfigurations());
        }
    }
}
