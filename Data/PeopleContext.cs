using zad3.Models;
using Microsoft.EntityFrameworkCore;

namespace zad3.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Check> Check { get; set; }
    }

}
