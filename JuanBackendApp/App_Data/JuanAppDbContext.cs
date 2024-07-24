using JuanBackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JuanBackendApp.App_Data
{
    public class JuanAppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public JuanAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
