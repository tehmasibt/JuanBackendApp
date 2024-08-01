using JuanBackendApp.App_Data;
using JuanBackendApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuanBackendApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly JuanAppDbContext _juanAppDbContext;

        public BasketController(JuanAppDbContext juanAppDbContext)
        {
            _juanAppDbContext = juanAppDbContext;
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if(id == null) return BadRequest();    
            var product = await _juanAppDbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> baskets;
            if (string.IsNullOrWhiteSpace(basket))
            {
                baskets = new();
            }
            else
            {
                baskets =JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            if(baskets.Exists(x => x.Id == id))
            {
                var basketProduct = baskets.FirstOrDefault(b => b.Id == id);
                basketProduct.Count++;
            }
            else
            {
                baskets.Add(new BasketVM() { Id = product.Id, Name = product.Name, Price = product.Price, Image = product.Image, Count = 1 });
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(baskets));
            return Ok();
        }
        public IActionResult GetBasket()
        {
            var result = HttpContext.Request.Cookies["basket"];
            return Json(result);
        }
    }
}
