using SafeDevelopHomeWork_1.Models;
using Microsoft.EntityFrameworkCore;

namespace SafeDevelopHomeWork_1.Data
{
    public class DataBase:DbContext
    {
       public DbSet<CardModel> Cards { get; set; }
       public DbSet<User> Users { get; set; }
        public DataBase()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cardsbase;Trusted_Connection=True;");
        }
    }
}
