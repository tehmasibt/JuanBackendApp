using JuanBackendApp.App_Data;
using JuanBackendApp.Interfaces;
using JuanBackendApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanBackendApp.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly JuanAppDbContext _juanAppDbContext;

        public LayoutService(JuanAppDbContext juanAppDbContext)
        {
            _juanAppDbContext = juanAppDbContext;
        }
        public IDictionary<string, string> GetSettings()
        {
            return _juanAppDbContext.Settings
               .Where(s => !s.IsDeleted)
               .ToDictionary(s => s.Key, s => s.Value);
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _juanAppDbContext.Products
                .AsNoTracking()
                .Where(a => !a.IsDeleted)
                .ToListAsync();
            return products;
        }
    }
}
