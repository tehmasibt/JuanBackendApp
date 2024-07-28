using JuanBackendApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace JuanBackendApp.App_Data
{
    public class JuanAppDbContext : DbContext
    {
        public JuanAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        
    }
}
