using BankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Data
{
    public class MainDBContext:DbContext
    {
     
        public MainDBContext(DbContextOptions<MainDBContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;DataBase=BankApi;Trusted_Connection=true;TrustServerCertificate=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BankId> Banks { get; set; }
        public DbSet<BankCard> BankCards { get; set; }

    }
}
