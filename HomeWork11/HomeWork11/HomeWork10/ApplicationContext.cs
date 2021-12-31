using HomeWork10.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork10
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cashe> Cashe { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> option)
            : base(option)
        {

        }
    }
}