using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Item> Items => Set<Item>();
    }
}
