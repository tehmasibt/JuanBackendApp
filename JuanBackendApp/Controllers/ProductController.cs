using JuanBackendApp.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanBackendApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
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
    }
}
