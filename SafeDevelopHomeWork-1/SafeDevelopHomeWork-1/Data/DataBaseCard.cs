using SafeDevelopHomeWork_1.Models;
using Microsoft.EntityFrameworkCore;

namespace SafeDevelopHomeWork_1.Data
{
    public class DataBaseCard:DbContext
    {
       public DbSet<CardModel> Cards { get; set; }
        public DataBaseCard()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CardsBase;Trusted_Connection=True;");
        }
    }
}
