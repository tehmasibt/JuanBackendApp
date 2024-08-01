using JuanBackendApp.App_Data;
using JuanBackendApp.Interfaces;
using JuanBackendApp.Models;
using JuanBackendApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuanBackendApp.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly JuanAppDbContext _juanAppDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LayoutService(JuanAppDbContext juanAppDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _juanAppDbContext = juanAppDbContext;
            _httpContextAccessor = httpContextAccessor;
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
        public IEnumerable<BasketVM> GetBasket()
        {
            List<BasketVM> list = new List<BasketVM>();
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            if (string.IsNullOrWhiteSpace(basket))
                return list;
            else
            {
                list = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                //foreach (var item in list)
                //{
                //    var existProduct = _juanAppDbContext.Products.FirstOrDefault(p => p.Id == item.Id);
                //    item.Name = existProduct.Name;
                //    item.Name = existProduct.Name;
                //    item.Price = existProduct.DisCountPrice > 0 ? existProduct.DisCountPrice : existProduct.Price;
                //    item.Image = existProduct.Image;
                //    item.EcoTax = existProduct.EcoTax;
                //}
                return list;
            }
        }
    }
}
