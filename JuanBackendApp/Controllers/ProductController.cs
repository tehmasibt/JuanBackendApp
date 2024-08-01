using JuanBackendApp.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanBackendApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly JuanAppDbContext _juanAppDbContext;
        public ProductController(JuanAppDbContext juanAppDbContext)
        {
            _juanAppDbContext = juanAppDbContext;
        }
        public async Task<IActionResult> Modal(int? id)
        {
            if (id == null) return BadRequest();
            var product =await _juanAppDbContext.Products
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(a=>a.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            return PartialView("_ModalPartial",product);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SearchProduct(string search)
       {
            var product = _juanAppDbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.Name.ToLower().Contains(search.ToLower()))
                .ToList();
            return PartialView("_SearchPartial", product);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            var product = await _juanAppDbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages)
                .Include(t => t.ProductColors)
                .ThenInclude(pc => pc.Color)
                .FirstOrDefaultAsync(p=>p.Id==id);
            if (product == null) return NotFound();
            var products = await _juanAppDbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.Id != product.Id)
                .Include(p => p.ProductImages)
                .Take(5)
                .ToListAsync();
            ViewBag.Products = products;
            return View(product);
        }
    }
}
