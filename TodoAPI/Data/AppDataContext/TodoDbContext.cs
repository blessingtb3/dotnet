//AppDataContext/TodoDBContext.cs
using DBSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoAPI.Models;

namespace TodoAPI.AppDataContext{

    //TodoDbContext class is the primary class that interacts with the database and also inherits from DbContext
    public class TodoDbContext : DbContext{

        //Constructor to inject DbSettings model
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options){}

        //DbSet property to represent the Todo table
        public DbSet<Todo> Todos { get; set; }

        //Confuring our model for the Todo entity 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Todo>()
                .ToTable("TodoAPI")
                .HasKey(x => x.Id);
        }
    }
}