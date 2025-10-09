using Microsoft.EntityFrameworkCore;
using MVCSample.Models;

namespace MVCSample.Data
{
    public class AppDbContext : DbContext
    {
         public	DbSet<TodoItem>	Items	{	get;	set;	}

        public string DbPath { get; }

        public AppDbContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "app.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
