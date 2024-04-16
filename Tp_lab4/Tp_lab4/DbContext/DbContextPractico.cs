using Microsoft.EntityFrameworkCore;
using Tp_lab4.Entities;

namespace Practico_labIV.dbContext
{
    public class DbContextPractico : DbContext
    {
        public DbContextPractico(DbContextOptions<DbContextPractico> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Marcelo",
                    Email = "Marcelo@gmail.com",
                    Address = "Donado 123"
                },
                new User
                {
                    Id = 2,
                    Name = "Pedro",
                    Email = "Pedro@gmail.com",
                    Address = "Wilde 123"
                },
                new User
                {
                    Id = 3,
                    Name = "Ana",
                    Email = "Ana@gmail.com",
                    Address = "Argentino 123"
                },
                new User
                {
                    Id = 4,
                    Name = "Sofia",
                    Email = "Sofia@gmail.com",
                    Address = "Cordoba 123"
                }
            );
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id_todo_item = 1,
                    Title = "Pelota",
                    Description = "Rugby"
                },
                new TodoItem
                {
                    Id_todo_item = 2,
                    Title = "Pelota",
                    Description = "Futbol"
                },
                new TodoItem
                {
                    Id_todo_item = 3,
                    Title = "Pelota",
                    Description = "Basquet"
                },
                new TodoItem
                {
                    Id_todo_item = 4,
                    Title = "Pelota",
                    Description = "Golf"
                },
                new TodoItem
                {
                    Id_todo_item = 5,
                    Title = "Pelota",
                    Description = "Tenis"
                }
            );

            modelBuilder.Entity<TodoItem>()
                .HasOne(t => t.User)
                .WithMany(u => u.TodoItems)
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
