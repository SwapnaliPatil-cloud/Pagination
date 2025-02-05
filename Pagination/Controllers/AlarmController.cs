using Microsoft.AspNetCore.Mvc;
using Pagination.Database;
using Pagination.Models;

namespace Pagination.Controllers
{
    [Controller]
    public class AlarmController : Controller
    {
        private readonly MyDbContext _context;
        public AlarmController(MyDbContext context)
        {
            _context = context;
        }
        public ActionResult Index(int page =1, int pageSize =10)
        {
            var totalRecords = _context.products.Count();
            var products = _context.products
                .OrderBy(p => p.Id)
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords/ pageSize);
            ViewBag.CurrentPage = page;

            return View(products);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product); // Return the same view in case of errors
        }
    }
}
